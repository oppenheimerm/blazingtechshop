
using BT.Core;

namespace BT.Datastore.EFCore
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Look for any .
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{Name="Home Entertainment", Code = "HMET",Icon="home-entertainment.jpg", Description="Deck your house out in all the latest tech."},
                new Category{Name="Computers",  Code = "CMPT", Icon="computers.jpg" , Description="Computer struggling to keep up?  Don't worry, we've got you covered!"},
                new Category{Name="Phones & Tablets", Code = "THTL", Icon="phones-and-tablets.jpg" , Description="One Stop shop for the latest in mobile and tablet technology."},
                new Category{Name="Cameras",  Code = "PHTO", Icon="cameras.jpg" , Description="Keeping you in the frame."},
                new Category{Name="Audio & Music", Code = "AUMC", Icon="audio-and-music.jpg" , Description="Sound worth listening to."},
                new Category{Name="Gaming & VR", Code = "VRGM", Icon="consoles-and-vr.jpg" , Description="Get your game face on!"},
                new Category{Name="Wearables", Code = "WRES", Icon="wearables.jpg" , Description="From smart watch to fitness trackers."},
                new Category{Name="Drones", Code = "DRNS", Icon="drones.jpg" , Description="These are the drones you're looking for!"},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            /*var brands = new Brand[]
            {
                new Brand{ Name = "Loewe", Code = "LOWE", About = "Loewe is committed to giving every product ameaning. A story. A purpose. Through dedicated precision work, we aim to establish Loewe as the epitome of luxury technical products. Thought through down to the smallest detail and made for absolute longevity, new design iconsare constantly being created in Kronach."}
            };*/

            /*var products = new Product[]
            {
                new Product{ Name = "", Description = "", BasePrice = , CategoryId = , BrandId =  },
                new Product{ Name = "", Description = "", BasePrice = , CategoryId = , BrandId =  },
                new Product{ Name = "", Description = "", BasePrice = , CategoryId = , BrandId =  },
                new Product{ Name = "", Description = "", BasePrice = , CategoryId = , BrandId =  },
            };*/
        }
            
    }
}
