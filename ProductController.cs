﻿using System;
using System.Collections.Generic;
using System.IO;
namespace GestionDeProductos
{
    public class ProductController
    {
        private static List<Product> Products = new List<Product>();
        private static int Index = 0;
        public static int Count = 0;
        public const int COLUMNS = 6;


        public static bool Save(Product product) 
        {
            bool exist = false;
            bool saved = false;

            Products.ForEach(p => { if (p.Id == product.Id) exist = true; });

            if (!exist)
            {
                Products.Add(product);
                saved = true;
                Count++;

            } else
            {
                Update(product);
            }

            return saved;
        }

        public static bool Update(Product product)
        {
            bool updated = false;

            for(int i = 0; i < Products.Count; i++)
            {
                if(Products[i].Id == product.Id)
                {
                    Products[i] = product;
                    updated = true;
                }
            }

            return updated;
        }

        public static bool Delete(String id)
        {
            bool deleted = false;
            List<Product> productsDeleted = new List<Product>();

            for (int i = 0; i < Products.Count; i++)
            {
                if(Products[i].Id != id)
                {
                    productsDeleted.Add(Products[i]);
                }
            }

            if(Products.Count>productsDeleted.Count)
            {
                Count--;
            }

            Products = productsDeleted;

            return deleted;
        }
        public static void DeleteAll()
        {
            Products.Clear();
            Count = 0;
            Index = 0;
        }

        public static Product Load(String id)
        {
            Product product = null;
            Products.ForEach(p =>
            {
                if (p.Id == id)
                    product = p;
            });

            return product;
        }

        public static bool HasNext()
        {
            bool HasNext;
            Product product = null;
            try
            {
                product = Products[Index];
                HasNext = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                HasNext = false;
            }

            return HasNext;
        }

        public static Product Next()
        {
            Product producto = null;
            try
            {
                producto = Products[Index];
                Index++;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Index = 0;
            }
            return producto;
        }

        public static Product Last()
        {
            Index = Products.Count - 1;
            return Products[Index];
        }

        public static Product First()
        {
            Product producto = null;
            Index = 0;
            if(Products.Count > 0)
            { producto = Products[Index]; }
            return producto;
        }

        public static String[] LoadString(String id)
        {
            String[] result = new string[COLUMNS];

            result[0] = Load(id).Id;
            result[1] = Load(id).Name;
            result[2] = Load(id).Quantity;
            result[3] = Load(id).Price;
            result[4] = Load(id).Description;
            result[5] = Load(id).TypeProduct.ToString();

            return result;
        }

        public static String[,] LoadStrings()
        {
            String[,] result = new string[Products.Count, COLUMNS];
            int i = 0;

            foreach (Product product in Products)
            {
                result[i, 0] = product.Id;
                result[i, 1] = product.Name;
                result[i, 2] = product.Quantity;
                result[i, 3] = product.Price;
                result[i, 4] = product.Description;
                result[i, 5] = product.TypeProduct.ToString();
                i++;
            }
            return result;
        }
        public static String[,] LoadStringsByType(int type)
        {
            String[,] result = new string[Products.Count, COLUMNS];
            int i = 0;

            foreach (Product product in Products)
            {
                if ((int)product.TypeProduct == type)
                {
                    result[i, 0] = product.Id;
                    result[i, 1] = product.Name;
                    result[i, 2] = product.Quantity;
                    result[i, 3] = product.Price;
                    result[i, 4] = product.Description;
                    result[i, 5] = product.TypeProduct.ToString();
                    i++;
                }
            }
            return result;
        }

        public static String[] NameColumns()
        {
            String[] result = new string[COLUMNS];
            result[0] = "Id";
            result[1] = "Nombre";
            result[2] = "Cantidad";
            result[3] = "Precio";
            result[4] = "Descripción";
            result[5] = "Tipo";

            return result;
        }
        public static List<Product> getProducts()
        {
            return Products;
        }

        public static String ToCsvString()
        {
            String resultString = "";
            Product producto = null;
            First();
            while(HasNext())
            {
                producto = Next();

                resultString += producto.Id + "; ";
                resultString += producto.Name + "; ";
                resultString += producto.Quantity + "; ";
                resultString += producto.Price + "; ";
                resultString += producto.Description + "; ";
                resultString += ((int)producto.TypeProduct).ToString() + "\n";
            }
            return resultString;
        }

        public static bool SaveCSV(string filePath)
        {
            bool result = false;
            First();
            try
            {
                StreamWriter streamWriter = new StreamWriter(filePath);
                if(ProductController.ToCsvString().Length == 0)
                {
                    throw new Exception();
                }
                streamWriter.Write(ProductController.ToCsvString());
                streamWriter.Close();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return result;
        }
        public static bool ImportCSV(string filePath)
        {
            Product ProductFromCSV = null;
            List<Product> ProductsFromCSV = new List<Product>();
            bool Result = false;
            string[] ProductString;
            string line;
            int Cont = 0;
            int t = 0;

            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                 line = streamReader.ReadLine();
                while (line != null)
                {
                    ProductString = line.Trim().Split(';');
                    if (ProductString.Length != 6)
                    {
                        throw new Exception();
                    }
                    ProductFromCSV = new Product();
                    ProductFromCSV.Id = ProductString[0].Trim();
                    ProductFromCSV.Name = ProductString[1].Trim();
                    ProductFromCSV.Quantity = ProductString[2].Trim();
                    ProductFromCSV.Price = ProductString[3].Trim();
                    ProductFromCSV.Description = ProductString[4].Trim();
                    t = int.Parse(ProductString[5].Trim());
                    ProductFromCSV.TypeProduct = (Product.Type)t;
                    if(ValidateProduct(ProductFromCSV))
                    {
                        ProductsFromCSV.Add(ProductFromCSV);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    ProductFromCSV = null;
                    line = streamReader.ReadLine();
                    Cont++;
                }
                streamReader.Close();
                if(Cont > 0)
                {
                    DeleteAll();
                    foreach(Product p in ProductsFromCSV)
                    {
                        Save(p);
                    }
                    Result = true;
                }
            } catch(Exception ex)
            {
                Result = false;
                Console.WriteLine(ex.Message);
            }


            return Result;
        }

        public static bool ValidateProduct(Product producto)
        {
            int i;
            int t;
            double d;
            bool result = true;
            // Checks the value of the text.
            if (!int.TryParse(producto.Id, out i) || producto.Id == "")
            {
                result = false;
                throw new Exception();
            }
            else if (producto.Name == "")
            {
                result = false;
                throw new Exception();
            }
            else if (!int.TryParse(producto.Quantity, out i) || producto.Quantity == "")
            {
                result = false;
                throw new Exception();
            }
            else if (!double.TryParse(producto.Price, out d) || producto.Price == "")
            {
                result = false;
                throw new Exception();
            }
            else if ((int)producto.TypeProduct < 0 || (int)producto.TypeProduct > 3)
            {
                result = false;
                throw new Exception();
            }

            return result;
        }

    }
}
