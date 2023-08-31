using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            GetUsers().ForEach(c => context.Users.Add(c));
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetGadgets().ForEach(g => context.Gadgets.Add(g));
            GetRoles().ForEach(r => context.Roles.Add(r));
            GetUserRoles().ForEach(r => context.UserRoles.Add(r));
            GetMenus().ForEach(r => context.menus.Add(r));
            GetRoleMenus().ForEach(r => context.RoleMenu.Add(r));


            context.Commit();
        }
        public static List<Menu> GetMenus()
        {
            return new List<Menu>
            {
                new Menu
                {
                    ID=1,
                    MenuName="Menu1",
                    ParrentMenuItemID=0,
                },
                new Menu
                {
                    ID=2,
                    MenuName="Library",
                    ParrentMenuItemID=0,
                },
                 new Menu
                {
                    ID=10,
                    MenuName="Emploees",
                    ParrentMenuItemID=0,
                    url="http://localhost:3523/Employee/Index",
                },
                   new Menu
                {
                    ID=10,
                    MenuName="Users",
                    ParrentMenuItemID=0,
                    url="http://localhost:3523/User/Index",
                },
                new Menu
                {
                    ID=3,
                    MenuName="menu3",
                    ParrentMenuItemID=0,
                },
                new Menu
                {
                    ID=4,
                    MenuName="menu4",
                    ParrentMenuItemID=0,
                },
                new Menu
                {
                    ID=5,
                    MenuName="menu1_1",
                    ParrentMenuItemID=1,
                },
                new Menu
                {
                    ID=6,
                    MenuName="menu1_2",
                    ParrentMenuItemID=1,
                }, 
                new Menu
                {
                    ID=7,
                    MenuName="Authors",
                    ParrentMenuItemID=2,
                     url="http://localhost:3523/Author/Index",
                },
                 new Menu
                {
                    ID=7,
                    MenuName="Genres",
                    ParrentMenuItemID=2,
                     url="http://localhost:3523/Genre/Index",
                },
                new Menu
                {
                    ID=8,
                    MenuName="menu3_1",
                    ParrentMenuItemID=3,
                },
                new Menu
                {
                    ID=9,
                    MenuName="menu4_1",
                    ParrentMenuItemID=4,
                }
            };
        }
        public static List<RoleMenu> GetRoleMenus()
        {
            return new List<RoleMenu>
            {
                new RoleMenu
                {
                    ID=1,
                    RoleID=1,
                    MenuID=1,
                },
                new RoleMenu
                {
                    ID=5,
                    RoleID=1,
                    MenuID=10,
                },
                new RoleMenu
                {
                    ID=2,
                    RoleID=2,
                    MenuID=2,
                },
                new RoleMenu
                {
                    ID=3,
                    RoleID=3,
                    MenuID=3,
                },
                new RoleMenu
                {
                    ID=4,
                    RoleID=4,
                    MenuID=4,
                }
            };
        }
        public static List<UserRoles> GetUserRoles()
        {
            return new List<UserRoles>
            {
                new UserRoles
                {
                    ID = 1,
                    UserID=1,
                    RoleID=1
                },
                new UserRoles
                {
                    ID=2,
                    UserID=1,
                    RoleID=2,
                },
                new UserRoles
                {
                    ID=3,
                    UserID=2,
                    RoleID=3,
                },new UserRoles
                {
                    ID=4,
                    UserID=2,
                    RoleID=3,
                },
                new UserRoles
                {
                    ID=5,
                    UserID=3,
                    RoleID=4,
                },
                new UserRoles
                {
                    ID=6,
                    UserID=3,
                    RoleID=4,
                }

            };
        }
        public static List<Roles> GetRoles()
        {
            return new List<Roles>
            {
                new Roles
                {
                    ID=1,
                    RoleName="Admin",
                },
                new Roles
                {
                    ID=2,
                    RoleName="Administrator",
                },
                new Roles
                {
                    ID=3,
                    RoleName="Moderator"
                },
                new Roles
                {
                    ID=4,
                    RoleName="Boss"
                }
            };
        }
        public static List<Users> GetUsers()
        {
            return new List<Users>
            {
                new Users
                {
                    ID = 1,
                    UserName="user1",
                    PassWord="paroli1",
                    LoginLocation="tbilisi",
                    IPAdress="kaiadres",
                    UserRoleTitle="admina"


                },
                new Users
                {
                    ID = 2,
                    UserName="user2",
                    PassWord="paroli2",
                    LoginLocation="tbilisi",
                    IPAdress="kaiadres",
                    UserRoleTitle="admina"

                },
                new Users
                {
                    ID = 3,
                    UserName="user3",
                    PassWord="paroli3",
                    LoginLocation="tbilisi",
                    IPAdress="kaiadres",
                    UserRoleTitle="admina"

                },


            };
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Tablets"
                },
                new Category {
                    Name = "Laptops"
                },
                new Category {
                    Name = "Mobiles"
                }
            };
        }

        private static List<Gadget> GetGadgets()
        {
            return new List<Gadget>
            {
                new Gadget {
                    Name = "ProntoTec 7",
                    Description = "Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
                    CategoryID = 1,
                    Price = 46.99m,
                    Image = "prontotec.jpg"
                },
                new Gadget {
                    Name = "Samsung Galaxy",
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    CategoryID = 1,
                    Price = 120.95m,
                    Image= "samsung-galaxy.jpg"
                },
                new Gadget {
                    Name = "NeuTab® N7 Pro 7",
                    Description = "NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
                    CategoryID = 1,
                    Price = 59.99m,
                    Image= "neutab.jpg"
                },
                new Gadget {
                    Name = "Dragon Touch® Y88X 7",
                    Description = "Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 54.99m,
                    Image= "dragon-touch.jpg"
                },
                new Gadget {
                    Name = "Alldaymall A88X 7",
                    Description = "This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 47.99m,
                    Image= "Alldaymall.jpg"
                },
                new Gadget {
                    Name = "ASUS MeMO",
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    CategoryID = 1,
                    Price = 94.99m,
                    Image= "asus-memo.jpg"
                },
                new Gadget {
                    Name = "ASUS 15.6-Inch",
                    Description = "Latest Generation Intel Dual Core Celeron 2.16 GHz Processor (turbo to 2.41 GHz)",
                    CategoryID = 2,
                    Price = 249.5m,
                    Image = "asus-latest.jpg"
                },
                new Gadget {
                    Name = "HP Pavilion 15-r030wm",
                    Description = "This Certified Refurbished product is manufacturer refurbished, shows limited or no wear, and includes all original accessories plus a 90-day warranty",
                    CategoryID = 2,
                    Price = 299.95m,
                    Image = "hp-pavilion.jpg"
                },
                new Gadget {
                    Name = "Dell Inspiron 15.6-Inch",
                    Description = "Intel Celeron N2830 Processor, 15.6-Inch Screen, Intel HD Graphics",
                    CategoryID = 2,
                    Price = 308.00m,
                    Image = "dell-inspiron.jpg"
                },
                new Gadget {
                    Name = "Acer Aspire E Notebook",
                    Description = "15.6 HD Active Matrix TFT Color LED (1366 x 768) 16:9 CineCrystal Display",
                    CategoryID = 2,
                    Price = 299.95m,
                    Image = "acer-aspire.jpg"
                },
                new Gadget {
                    Name = "HP Stream 13",
                    Description = "Intel Celeron N2840 Processor. 2 GB DDR3L SDRAM, 32 GB Solid-State Drive and 1TB OneDrive Cloud Storage for one year",
                    CategoryID = 2,
                    Price = 202.99m,
                    Image = "hp-stream.jpg"
                },
                new Gadget {
                    Name = "Nokia Lumia 521",
                    Description = "T-Mobile Cell Phone 4G - White. 5MP Camera - Snap creative photos with built-in digital lenses",
                    CategoryID = 3,
                    Price = 63.99m,
                    Image = "nokia-lumia.jpg"
                },
                new Gadget {
                    Name = "HTC Desire 816",
                    Description = "13 MP Rear Facing BSI Camera / 5 MP Front Facing",
                    CategoryID = 3,
                    Price = 177.99m,
                    Image = "htc-desire.jpg"
                },
                new Gadget {
                    Name = "Sanyo Innuendo",
                    Description = "Uniquely designed 3G-enabled messaging phone with side-flipping QWERTY keyboard and external glow-thru OLED dial pad that 'disappears' when not in use",
                    CategoryID = 3,
                    Price = 54.99m,
                    Image = "sanyo-innuendo.jpg"
                },
                new Gadget {
                    Name = "Ulefone N9000",
                    Description = "Unlocked world GSM phone. 3G-850/2100, 2G -850/900/1800/1900",
                    CategoryID = 3,
                    Price = 133.99m,
                    Image = "ulefone.jpg"
                }
 
            };
        }
    }
}
