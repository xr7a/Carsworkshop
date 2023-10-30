using FluentMigrator;

namespace Migrations
{
    [Migration(1)]
    public class OrderMigration : Migration
    {
        public override void Up()
        {
            Create.Table("orders")
                .WithColumn("order_id").AsInt64().PrimaryKey().Identity()
                .WithColumn("car_id").AsInt64().Unique()
                .WithColumn("user_id").AsInt64()
                .WithColumn("ordertime").AsString()
                .WithColumn("orderdescription").AsString()
                .WithColumn("orderstatus").AsString();
            Insert.IntoTable("orders")
                .Row(new { car_id = "1", user_id = "1", ordertime = "09.10.2023", orderdescription = "+Починить двигатель", orderstatus = "Выполняется" });
        }

        public override void Down()
        {
            Delete.Table("orders");
        }
    }
}