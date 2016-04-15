namespace AutoVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOVENTAS_CARS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compras", "numeroTarjeta", c => c.String(nullable: false));
            AlterColumn("dbo.Ventas", "precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ventas", "precio", c => c.Int(nullable: false));
            AlterColumn("dbo.Compras", "numeroTarjeta", c => c.Int(nullable: false));
        }
    }
}
