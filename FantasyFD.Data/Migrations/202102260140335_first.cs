namespace FantasyFD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        HomeScore = c.Double(nullable: false),
                        AwayScore = c.Double(nullable: false),
                        DateOfGame = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerFirstName = c.String(nullable: false),
                        PlayerLastName = c.String(nullable: false),
                        PlayerPosition = c.String(nullable: false),
                        PlayerJerseyNumber = c.Int(nullable: false),
                        PlayerHeightByInches = c.Double(nullable: false),
                        PlayerWeightByPounds = c.Double(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.PlayerStats",
                c => new
                    {
                        PlayerStatsId = c.Int(nullable: false, identity: true),
                        PassingYards = c.Int(nullable: false),
                        PassingTouchdowns = c.Int(nullable: false),
                        InterceptionThrown = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        RushingAttempts = c.Int(nullable: false),
                        RushingTouchDowns = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        Catches = c.Int(nullable: false),
                        ReceivingTouchDowns = c.Int(nullable: false),
                        Fumbles = c.Int(nullable: false),
                        Tackles = c.Int(nullable: false),
                        Sacks = c.Double(nullable: false),
                        Interceptions = c.Int(nullable: false),
                        ForcedFumbles = c.Int(nullable: false),
                        FumbleRecovery = c.Int(nullable: false),
                        Safety = c.Int(nullable: false),
                        BlockedKick = c.Int(nullable: false),
                        ReturnTouchDown = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerStatsId)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TeamGames",
                c => new
                    {
                        Team_TeamId = c.Int(nullable: false),
                        Games_GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_TeamId, t.Games_GameId })
                .ForeignKey("dbo.Team", t => t.Team_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Games_GameId, cascadeDelete: true)
                .Index(t => t.Team_TeamId)
                .Index(t => t.Games_GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.PlayerStats", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.TeamGames", "Games_GameId", "dbo.Games");
            DropForeignKey("dbo.TeamGames", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.TeamGames", new[] { "Games_GameId" });
            DropIndex("dbo.TeamGames", new[] { "Team_TeamId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PlayerStats", new[] { "PlayerId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropTable("dbo.TeamGames");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PlayerStats");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Games");
        }
    }
}
