namespace Spending.Repository.Data.Sql.Commands
{
    public static class SpendingCommands
    {
        public const string GetSpendingYears = @"
            SELECT DISTINCT
                YEAR,
	            SUM(ParcelValue) as TOTALVALUE
            FROM DBO.GASTOS
            group by YEAR ";

        public const string GetSpendingMonthsByYear = @"
            SELECT DISTINCT
	            G.Month ,
	            DATENAME(mm, datefromparts(year(GETDATE()), G.Month, DAY(GETDATE()))) as MonthDescription,
                (select sum(ParcelValue) from dbo.Gastos as gg where g.Month = gg.Month and g.Year = gg.Year) as TotalValue, 
	            p.Description as ProductDescription, 
	            g.Parcel as 'CurrentParcel', 
	            (p.Parcel - MAX(g.Parcel)) as 'RemaingParcel', 
	            g.Month,
	            g.ParcelValue
            FROM 
	            DBO.GASTOS as G
	            INNER JOIN DBO.Produto AS P ON G.ProductId = P.Id
            WHERE 
	            G.YEAR = @YEAR
            group by 
	            G.MONTH,
	            p.Description, 
	            g.parcel, 
	            p.Parcel, 
	            g.Year,
	            g.ParcelValue";

        public const string GetSpendingProducts = @"
            SELECT DISTINCT
	            G.Month,
				g.Year,
	            DATENAME(mm, datefromparts(year(GETDATE()), G.Month, DAY(GETDATE()))) as MonthDescription,
                (select Price from dbo.Produto as pp where p.Id = pp.Id) as TotalValue, 
				p.Id,
	            p.Description as ProductDescription, 
	            g.Parcel as 'CurrentParcel', 
	            (p.Parcel - MAX(g.Parcel)) as 'RemaingParcel', 
	            g.Month,
	            g.ParcelValue
            FROM 
	            DBO.GASTOS as G
	            INNER JOIN DBO.Produto AS P ON G.ProductId = P.Id
            group by 
	            G.MONTH,
				p.Id,
	            p.Description, 
				p.Price,
	            g.parcel, 
	            p.Parcel, 
	            g.Year,
	            g.ParcelValue
			ORDER BY
				p.Description,
				g.Year,
				G.Month";
    }
}
