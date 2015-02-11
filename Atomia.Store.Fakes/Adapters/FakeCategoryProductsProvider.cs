﻿using Atomia.Store.Core;
using System.Collections.Generic;
using System.Linq;

namespace Atomia.Store.Fakes.Adapters
{
    public class FakeCategoryProductsProvider : IProductsProvider
    {
        public string Name
        {
            get { return "Category"; }
        }

        public Product GetProduct(string articleNumber)
        {
            var allProducts = GetAllProducts();
            return allProducts.FirstOrDefault(p => p.ArticleNumber == articleNumber);
        }

        public IEnumerable<Product> GetProducts(ICollection<SearchTerm> terms)
        {
            var allProducts = GetAllProducts();
            var category = terms.First().Value;

            return allProducts.Where(p => p.Category == category);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var renewalPeriods = new List<RenewalPeriod> { new RenewalPeriod { Period = 1, Unit = "YEAR" } };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "DNS Package",
                    Category = "Hosting",
                    ArticleNumber = "DNS-PK",
                    Description = "DNS Package<ul><li>Domain management</li><li>DNS</li></br></br></ul>",
                    PricingVariants = new List<PricingVariant>
                    {
                        new PricingVariant
                        {
                            Price = 0,
                            RenewalPeriod = null
                        }
                    },
                    CustomAttributes = new List<CustomAttribute>
                    {
                        new CustomAttribute {
                            Name = "tos",
                            Value = "defaultTOS"
                        }
                    }
                },
                new Product
                {
                    Name = "Gold Package",
                    Category = "Hosting",
                    ArticleNumber = "HST-GLD",
                    Description = "Basic hosting package<ul><li>Web hosting</li><li>Email</li><li>Domain management</li><li>DNS</li></ul>",
                    PricingVariants = new List<PricingVariant>
                    {
                        new PricingVariant 
                        {
                            Price = 10m,
                            RenewalPeriod = new RenewalPeriod() { Period = 1, Unit = "YEAR" }
                        }
                    },
                    CustomAttributes = new List<CustomAttribute>
                    {
                        new CustomAttribute {
                            Name = "Fizz", 
                            Value = "Buzz"
                        },
                        new CustomAttribute {
                            Name = "Foo", 
                            Value = "Bar" 
                        },
                        new CustomAttribute {
                            Name = "tos",
                            Value = "defaultTOS"
                        }
                    }
                },
                new Product
                {
                    Name = "Platinum package",
                    Category = "Hosting",
                    ArticleNumber = "HST-PLT",
                    Description = "Premium hosting package<ul><li>Web hosting</li><li>Email</li><li>Domain management</li><li>DNS</li></ul>",
                    PricingVariants = new List<PricingVariant>
                    {
                        new PricingVariant 
                        {
                            Price = 10m,
                            RenewalPeriod = new RenewalPeriod() { Period = 6, Unit = "MONTH" }
                        },
                        new PricingVariant
                        {
                            Price = 20m,
                            RenewalPeriod = new RenewalPeriod() { Period = 1, Unit = "YEAR" }
                        },
                        new PricingVariant {
                            Price = 40m,
                            RenewalPeriod = new RenewalPeriod() { Period = 2, Unit = "YEAR" }
                        },
                    },
                    CustomAttributes = new List<CustomAttribute>
                    {
                        new CustomAttribute {
                            Name = "tos",
                            Value = "defaultTOS"
                        }
                    }
                },
                new Product
                {
                    Name = "MySQL Database",
                    Category = "Extra service",
                    ArticleNumber = "XSV-MYSQL",
                    Description = "MySQL Database addon.",
                    PricingVariants = new List<PricingVariant>
                    {
                        new PricingVariant
                        {
                            Price = 10m,
                            RenewalPeriod = new RenewalPeriod() { Period = 1, Unit = "YEAR" }
                        },
                        new PricingVariant
                        {
                            Price = 20m,
                            RenewalPeriod = new RenewalPeriod() { Period = 2, Unit = "YEAR" }
                        },
                    },
                },
                new Product
                {
                    Name = "MSSQL Database",
                    Category = "Extra service",
                    ArticleNumber = "XSV-MSSQL",
                    Description = "MSSQL Database addon.",
                    PricingVariants = new List<PricingVariant>
                    {
                        new PricingVariant
                        {
                            Price = 10m,
                            RenewalPeriod = new RenewalPeriod() { Period = 1, Unit = "YEAR" }
                        },
                        new PricingVariant
                        {
                            Price = 20m,
                            RenewalPeriod = new RenewalPeriod() { Period = 2, Unit = "YEAR" }
                        },
                    },
                },
                new Product
                {
                    Name = ".com",
                    ArticleNumber = "DMN-COM",
                    Description = "Domain registration .com",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>
                    {
                        new CustomAttribute {
                            Name = "tos",
                            Value = "TOS_core"
                        }
                    }
                },
                new Product
                {
                    Name = ".se",
                    ArticleNumber = "DMN-SE",
                    Description = "Domain registration .se",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>()
                },

                new Product
                {
                    Name = ".eu",
                    ArticleNumber = "DMN-EU",
                    Description = "Domain registration .eu",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>()
                },

                new Product
                {
                    Name = ".net",
                    ArticleNumber = "DMN-NET",
                    Description = "Domain registration .net",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>()
                },

                new Product
                {
                    Name = ".info",
                    ArticleNumber = "DMN-INFO",
                    Description = "Domain registration .info",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>()
                },

                new Product
                {
                    Name = ".biz",
                    ArticleNumber = "DMN-BIZ",
                    Description = "Domain registration .biz",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    CustomAttributes = new List<CustomAttribute>()
                },

                new Product
                {
                    Name = ".rs",
                    ArticleNumber = "DMN-RS",
                    Description = "Domain registration .rs",
                    PricingVariants = renewalPeriods.Select(r => new PricingVariant { Price = 10m, RenewalPeriod = r }).ToList(),
                    Category = "Domain",
                    CustomAttributes = new List<CustomAttribute>()
                }
            };

            return products;
        }
    }
}
