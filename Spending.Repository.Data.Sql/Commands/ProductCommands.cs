namespace Spending.Repository.Data.Sql.Commands
{
    public static class ProductCommands
    {
        public const string GetAll = @"
            SELECT
                P.*,
                G.*
            FROM DBO.GASTOS AS G
                INNER JOIN DBO.PRODUTO AS P ON P.SPENDINGID = G.ID";

        public const string GetById = @"
            SELECT
                P.*,
                G.*
            FROM DBO.GASTOS AS G
                INNER JOIN DBO.PRODUTO AS P ON P.SPENDINGID = G.ID
            WHERE P.ID = @ID";
    }
}
