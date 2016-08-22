//namespace OGL.Migrations
//{
//    using System.Data.Entity.Migrations;
    
//    public partial class tree : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Category",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Nazwa = c.String(nullable: false),
//                        ParentId = c.Int(nullable: false),
//                        MetaTytul = c.String(maxLength: 72),
//                        MetaOpis = c.String(maxLength: 160),
//                        MetaSlowa = c.String(maxLength: 160),
//                        Tresc = c.String(maxLength: 600),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.AdCategory",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        KategoriaId = c.Int(nullable: false),
//                        OgloszenieId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Category", t => t.KategoriaId)
//                .ForeignKey("dbo.MyAd", t => t.OgloszenieId)
//                .Index(t => t.KategoriaId)
//                .Index(t => t.OgloszenieId);
            
//            CreateTable(
//                "dbo.MyAd",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Tresc = c.String(maxLength: 600),
//                        Tytul = c.String(maxLength: 70),
//                        DataDodania = c.DateTime(nullable: false),
//                        Stan = c.Int(nullable: false),
//                        OstatnioEdytowane = c.DateTime(),
//                        IdOstatnioEdytowane = c.String(),
//                        UzytkownikId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.AspNetUsers", t => t.UzytkownikId, cascadeDelete: true)
//                .Index(t => t.UzytkownikId);
            
//            CreateTable(
//                "dbo.AspNetUsers",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        Email = c.String(maxLength: 256),
//                        EmailConfirmed = c.Boolean(nullable: false),
//                        PasswordHash = c.String(),
//                        SecurityStamp = c.String(),
//                        PhoneNumber = c.String(),
//                        PhoneNumberConfirmed = c.Boolean(nullable: false),
//                        TwoFactorEnabled = c.Boolean(nullable: false),
//                        LockoutEndDateUtc = c.DateTime(),
//                        LockoutEnabled = c.Boolean(nullable: false),
//                        AccessFailedCount = c.Int(nullable: false),
//                        UserName = c.String(nullable: false, maxLength: 256),
//                        Wiek = c.Int(),
//                        Pseudonim = c.String(),
//                        Imie = c.String(),
//                        Nazwisko = c.String(),
//                        Discriminator = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
//            CreateTable(
//                "dbo.AspNetUserClaims",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        ClaimType = c.String(),
//                        ClaimValue = c.String(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.AspNetUserLogins",
//                c => new
//                    {
//                        LoginProvider = c.String(nullable: false, maxLength: 128),
//                        ProviderKey = c.String(nullable: false, maxLength: 128),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.AspNetUserRoles",
//                c => new
//                    {
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        RoleId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.UserId, t.RoleId })
//                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId)
//                .Index(t => t.RoleId);
            
//            CreateTable(
//                "dbo.AspNetRoles",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        Name = c.String(nullable: false, maxLength: 256),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
//            DropForeignKey("dbo.MyAd", "UzytkownikId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AdCategory", "OgloszenieId", "dbo.MyAd");
//            DropForeignKey("dbo.AdCategory", "KategoriaId", "dbo.Category");
//            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
//            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
//            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
//            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
//            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
//            DropIndex("dbo.AspNetUsers", "UserNameIndex");
//            DropIndex("dbo.MyAd", new[] { "UzytkownikId" });
//            DropIndex("dbo.AdCategory", new[] { "OgloszenieId" });
//            DropIndex("dbo.AdCategory", new[] { "KategoriaId" });
//            DropTable("dbo.AspNetRoles");
//            DropTable("dbo.AspNetUserRoles");
//            DropTable("dbo.AspNetUserLogins");
//            DropTable("dbo.AspNetUserClaims");
//            DropTable("dbo.AspNetUsers");
//            DropTable("dbo.MyAd");
//            DropTable("dbo.AdCategory");
//            DropTable("dbo.Category");
//        }
//    }
//}
