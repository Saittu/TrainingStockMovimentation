CREATE OR ALTER PROCEDURE sp_MovimentacaoEstoque @ProductId BIGINT, @Type INT, @Date DATETIME, @QuantityProduct INT, @ContaId BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ValorMovimento DECIMAL(18,2),
			
			@ValorProduto DECIMAL(18,2),

			@ContaExiste BIGINT,
			@ProdutoExiste BIGINT,
			@FlContaBancaria BIT,
			@ValorAtualConta DECIMAL(18,2);

	SET @Date = ISNULL(@Date, GETDATE());
	
	SELECT 
		@ContaExiste = C.Id, 
		@FlContaBancaria = C.FlContaAtiva
	FROM ContaBC C 
	WHERE C.Id = @ContaId;

	IF @ContaExiste IS NULL
		THROW 50001, 'A conta não foi encontrada para cadastro.', 1;

	IF @FlContaBancaria = 0
		THROW 50002, 'A conta está desativada, escolha outra conta para continuar.', 1;

	SELECT 
		@ProdutoExiste = P.Id, 
		@ValorProduto = p.Price 
	FROM Products P 
	WHERE P.Id = @ProductId

	IF @ProdutoExiste IS NULL
		THROW 50003, 'O produto não existe para cadastro.', 1;

	BEGIN TRY
		BEGIN TRANSACTION
			
			SET @ValorMovimento = @ValorProduto * @QuantityProduct;

			UPDATE P 
			SET
				P.Amount =
					CASE
						WHEN @Type = 1 THEN P.Amount - @QuantityProduct
						WHEN @Type = 2 THEN P.Amount + @QuantityProduct
					END
			FROM Products P 
			WHERE P.Id = @ProductId AND (@Type = 1 OR (@Type = 2 AND P.Amount >= @QuantityProduct));

			IF @@ROWCOUNT = 0
				THROW 50004, 'Estoque insulficiente para a operação de saida.', 1;

			UPDATE C
			SET 
				C.Balance =
					CASE 
						WHEN @Type = 1 THEN Balance + @ValorMovimento
						WHEN @TYPE = 2 THEN Balance - @ValorMovimento
					END
			FROM ContaBC C
			WHERE C.Id = @ContaId AND (@Type = 1 OR (@Type = 2 AND Balance >= @ValorMovimento))

			IF @@ROWCOUNT = 0
				THROW 50005, 'O saldo bancario é insulficiente para essa movimentação de estoque', 1;

			INSERT INTO StockMovement (ProductId, Date, QuantityProduct, ContaId, Type, ValueMovimentation) VALUES (@ProductId, @Date, @QuantityProduct, @ContaId, @Type, @ValorMovimento)

		COMMIT
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK;

		THROW
	END CATCH
END