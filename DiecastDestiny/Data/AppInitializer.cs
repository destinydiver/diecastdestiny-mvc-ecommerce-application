using DiecastDestiny.Data.Enums;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context!.Database.EnsureCreated();

                // Add seed data
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            BrandName = "Matchbox",
                            LogoURL = "../images/brandlogos/Matchbox.png",
                            History = "Almost 70 years ago Lesney revolutionized the toy market. John W. Odell (Jack Odell), " +
                            "Leslie Charles Smith and Rodney Smith founded the company, which was named after the combination of the names " +
                            "Leslie and Rodney – Les–ney. Matchbox was created by Lesney Products in 1953. Lesney began manufacturing " +
                            "diecast toys in 1948."
                        },
                        new Brand()
                        {
                            BrandName = "Hot Wheels",
                            LogoURL = "../images/brandlogos/HotWheels1.png",
                            History = "For over 50 years Hot Wheels has been a part of the lives of millions of children and adults. " +
                            "What started as just a toy, has become a fever among collectors and aficionados of the brand. " +
                            "Hot Wheels came about when Elliot Handler, one of Mattel’s co-founders, challenged his team to create a toy car " +
                            "that was cooler and performed better than anything else on the market.He was impressed with the wheel design when " +
                            "he saw the first prototype.Soon, agreements were closed with car manufacturers with the appropriate licenses for the " +
                            "sale of the miniatures.The first Hot Wheels to hit the market was the Custom Camaro, soon followed by 15 more releases." +
                            "These first 16 Hot Wheels releases became known as the “Sweet 16”. These were the first in the Red Line Series, " +
                            "which had a red stripe on the tires.Tracks and sets, where you could play with the cars, were also released."
                        },
                        new Brand()
                        {
                            BrandName = "Corgi Toys",
                            LogoURL = "../images/brandlogos/CorgiToys2.jpg",
                            History = "Corgi Toys (trademark) is the brand name of a range of die-cast toy vehicles created by Mettoy and currently owned by Hornby. " +
                            "The Mettoy (Metal Toy) company was founded in 1933 by German émigré Philip Ullmann in Northampton, England, where he was later joined by " +
                            "South African–born German Arthur Katz, who had previously worked for Ullmann at his toy company Tipp and Co of Nuremberg.After dabbling " +
                            "for some years in the model car market, they decided to produce a range of die - cast toy vehicles as competition to Meccano's Dinky model " +
                            "cars, which had dominated the British market for many years. Corgi Toys were introduced in the UK in July 1956 and were manufactured in Swansea, " +
                            "Wales, for 27 years before the company went into liquidation. A management buy-out re-formed the company as Corgi Toys Limited in March 1984. In 1989, " +
                            "the management sold the Corgi brand to Mattel and the factory was retained under the name of Microlink Industries Ltd. In 1995, Corgi regained " +
                            "its independence as a new company, Corgi Classics Limited, and moved to new premises in Leicester. The Corgi brand was acquired by Hornby " +
                            "in 2008.The range was exported worldwide and sold in large numbers.Some of the best known and most popular models were of cars made famous " +
                            "in film and television such as the Batmobile, Chitty Chitty Bang Bang and James Bond's Aston Martin DB5 – which remains the largest selling " +
                            "toy car ever produced. Although the largest single vehicle type featured in the Corgi Toys range were models of cars from manufacturers around " +
                            "the world, this article sub-divides vehicles into genres, wherever possible, to allow a more detailed look at the variety of " +
                            "models produced by the company."
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>()
                    {
                        new Manufacturer()
                        {
                            ManufacturerName = "Lesney",
                            LogoURL = "../images/brandlogos/Lesney-Products-Logo.jpg",
                            History = "Almost 70 years ago Lesney revolutionized the toy market. John W. Odell (Jack Odell), " +
                            "Leslie Charles Smith and Rodney Smith founded the company, which was named after the combination of the names " +
                            "Leslie and Rodney – Les–ney. Matchbox was created by Lesney Products in 1953. Lesney began manufacturing " +
                            "diecast toys in 1948."
                        },
                        new Manufacturer()
                        {
                            ManufacturerName = "Mettoy",
                            LogoURL = "../images/brandlogos/Mettoy_Playthings,_logo_(~1962).jpg",
                            History = "Mettoy (Metal Toy  abbrevt'd) was a British manufacturing company founded in 1933 by German émigré Philip " +
                            "Ullmann, who was later joined by South African-born German Arthur Katz. They moved to Britain following Hitler's rise " +
                            "to power in 1933Ullman and Katz set up their toy-manufacturing business on 31 August 1932. They initially produced " +
                            "very similar tinplate toys to those being made in Germany. During the Second World War the factory manufactured not " +
                            "only munitions but also a cooking stove for troops posted in tropical jungle environments.The firm is most famous for " +
                            "the line of die - cast toy motor vehicles produced by its Corgi Toys branch, created in 1956.In the same year Mettoy " +
                            "merged with the Playcraft model railway and slot car company.The company was sold in 1984, with the assets of the company " +
                            "transferred to independent company Corgi Classics, but it folded shortly afterward."
                        },
                        new Manufacturer()
                        {
                            ManufacturerName = "Mattel",
                            LogoURL = "../images/brandlogos/Mattel-Logo-500x315.png",
                            History = "Mattel, Inc. is an American multinational toy manufacturing and entertainment company founded in Los Angeles " +
                            "by Harold Matson and the husband-and-wife duo of Ruth and Elliot Handler in January 1945 and headquartered in El Segundo, " +
                            "California. Mattel has a presence in 35 countries and territories; its products are sold in more than 150 countries.  " +
                            "It is the world's second largest toy maker in terms of revenue, after The Lego Group. Two of its historic and most " +
                            "valuable brands, Barbie and Hot Wheels, were respectively named the top global toy property and the top-selling global " +
                            "toy of the year for 2020 and 2021 by The NPD Group.  The company name chosen is a portmanteau of the surname of Matson " +
                            "and first name of Elliot, with former chairman and CEO Bob Eckert.  The founders, according to Elliot, couldn't fit Ruth's " +
                            "name into that of their company. The company began selling picture frames and later dollhouse furniture out of the scraps " +
                            "from those frames. Matson sold his share and stake to the Handlers due to poor health the following year, with Handler's " +
                            "wife, Ruth, taking over his stake.  In 1947, the company had its first successful toy, a ukulele called Uke-A-Doodle. " +
                            "On May 18, 1968, Hot Wheels was released to the market.  Hot Wheels was invented by a team of Mattel inventors, " +
                            "which included a rocket scientist and a car designer.  In 1969, Mattel changed the Mattel Creations and the " +
                            "Mattel, Inc. – Toymakers marketing brands to just Mattel and launched the Red Sun logo with the Mattel wordmark in all " +
                            "capitals for better identity. In 1970, Hot Wheels forged a sponsorship agreement with drag racing drivers Don “The Snake” " +
                            "Prudhomme and Tom “The Mongoose” McEwen.In addition to other marketing measures, the two racers’ cars, a yellow Barracuda " +
                            "and a red Duster, were reproduced as Hot Wheels toys."
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductImageURL = "../images/BedfordTractor/M2B_Bedford1.jpg",
                            ProductName = "Bedford Tractor & Davies Tyres Trailer",
                            Model = "Major Pack M2B",
                            Price = 89.00,
                            ModelYear = 1961,
                            BrandId = 1,
                            //Brand = Brand.Matchbox,
                            ProductLine = ProductLine.MajorPacks,
                            ManufacturerId = 1,
                            Description = "Matchbox Major Pack M2B BEDFORD TRACTOR & YORK ‘DAVIES TYRES’ TRAILER (no box) " +
                                "in stunning orange and silver-grey, with detachable articulated trailer, rear opening doors and gorgeous decals from 1961!"
                        },
                        new Product()
                        {
                            ProductImageURL = "../images/1966_Ford_Police_Car/pic1.jpg",
                            ProductName = "1966 Ford Galaxy Police Car",
                            Model = "55C",
                            Price = 55.00,
                            ModelYear = 1966,
                            BrandId = 1,
                            //Brand = Brand.Matchbox,
                            ProductLine = ProductLine.One2SeventyFive,
                            ManufacturerId = 1,
                            Description = "FORD GALAXIE POLICE CAR in white, with white interior / driver figure and black plastic wheels (BPW), " +
                                            "with original matching Type E Box from 1966!"
                        },
                        new Product()
                        {
                            ProductImageURL = "../images/Porsche_917/pic1.jpg",
                            ProductName = "Porsche 917",
                            Model = "Redline Porsche 917",
                            Price = 175.00,
                            ModelYear =  1970,
                            BrandId = 2,
                            //Brand = Brand.HotWheels,
                            ProductLine = ProductLine.RedLineSeries,
                            ManufacturerId = 3,
                            Description = " Hot Wheels Redline PORSCHE 917 in beautiful Gray Enamel with desirable white interior and " +
                                    "opening rear engine hatch in incredible Mint minus condition from 1970, Year Three for Hot Wheels!"
                        },
                        new Product()
                        {
                            ProductImageURL = "../images/Bentley/pic1.jpg",
                            ProductName = "1927 Bentley",
                            Model = "#9001",
                            Price = 70.00,
                            ModelYear = 1964,
                            BrandId = 3,
                            //Brand = Brand.CorgiToys,
                            ProductLine = ProductLine.CorgiClassics,
                            ManufacturerId = 2,
                            Description = "Corgi Classics’ 1927 BENTLEY (#9001) in green with driver and original box & foam insert, " +
                            "first introduced in 1964! This UK casted Bentley Racer #3 is in gorgeous condition with so much incredible detail!"
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Supplier>()
                    {
                        new Supplier()
                        {
                            Name = "Matchbox Mike",
                            Email = "mikeyM@tinycar.com",
                            Phone = "502-112-2334",
                            Description = "Mike is the top supplier of Matchbox toys in the diecast universe."
                        },
                        new Supplier()
                        {
                            Name = "Chucks Diecast Dynasty",
                            Email = "diecastdynasty.com",
                            Phone = "202-112-2222",
                            Description = "The person to go to in the New York area!"
                        },
                        new Supplier()
                        {
                            Name = "Toy Car Central",
                            Email = "Janice@toycarcental.com",
                            Phone = "123-456-7890",
                            Description = "The largest supplier on diecast on the west coast."
                        },
                        new Supplier()
                        {
                            Name = "Acme Toy Company",
                            Email = "Charlie@acmeToys.com",
                            Phone = "987-654-3210",
                            Description = "The Coyote's go to supplier."
                        }
                    });

                    context.SaveChanges();
                }

//                if (!context.ProductsSuppliers.Any())
//{
//                    context.AddRange(new List<ProductSupplier>()
//{
//                        new ProductSupplier()
//                        {
//                            ProductId = 1,
//                            SupplierId = 2
//                        },
//                        new ProductSupplier()
//                        {
//                            ProductId = 2,
//                            SupplierId = 3
//                        },
//                        new ProductSupplier()
//{
//                            ProductId = 3,
//                            SupplierId = 4
//                        },
//                        new ProductSupplier()
//{
//                            ProductId = 4,
//                            SupplierId = 1
//                        }
//                    });
//                    context.SaveChanges();
//                }

            }
        }
    }
}
