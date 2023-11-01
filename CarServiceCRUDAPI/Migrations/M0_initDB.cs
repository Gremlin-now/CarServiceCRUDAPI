using FluentMigrator;

namespace CarServiceCRUDAPI.Migrations
{
    [Migration(0)]
    public class M0_initDB : Migration
    {
        public override void Up()
        {
            Create.Table("clients")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("surname").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("phonenumber").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("address").AsString(255).NotNullable().WithDefaultValue("");
            Create.Table("cars")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("mark").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("model").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("releaseyear").AsInt32().NotNullable().WithDefaultValue(1990)
                .WithColumn("vincode").AsString(255).NotNullable().WithDefaultValue("");
            Create.Table("orders")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("carid").AsInt32().NotNullable().ForeignKey("cars", "id")
                .WithColumn("clientid").AsInt32().NotNullable().ForeignKey("clients", "id")
                .WithColumn("date").AsDate().NotNullable()
                .WithColumn("description").AsString()
                .WithColumn("status").AsString();
        }
        public override void Down()
        {
            Delete.Table("Clients");
            Delete.Table("Cars");
            Delete.Table("Orders");
        }
    }
}
