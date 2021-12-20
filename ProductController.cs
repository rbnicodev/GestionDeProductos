using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos
{
    public class ProductController
    {
        private static List<Product> Products = new List<Product>();
        private static int index = 0;
        public const int Columns = 6;
        public static int Count = 0; 


        public static bool save(Product product) 
        {
            bool exist = false;
            bool saved = false;

            Products.ForEach(p => { if (p.Id == product.Id) exist = true; });

            if (!exist)
            {
                Products.Add(product);
                saved = true;
            }

            Count++;
            return saved;
        }

        public static bool update(Product product)
        {
            bool updated = false;

            Products.ForEach(p =>
            {
                if (p.Id == product.Id)
                {
                    p = product;
                    updated = true;
                }
            });

            return updated;
        }

        public static bool delete(String id)
        {
            bool deleted = false;

            Products.ForEach(p =>
            {
                if (p.Id == id)
                {
                    Products.Remove(p);
                    deleted = true;
                }
            });

            return deleted;
        }

        public static Product load(String id)
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
            Product product = Products[index + 1];

            if (product != null)
                HasNext = true;
            else
                HasNext = false;

            return HasNext;
        }

        public static Product next()
        { 
            return Products[index];
            index++;
        }

        public static Product last()
        {
            index = Products.Count - 1;

            return Products[index];
        }

        public static Product first()
        {
            index = 0;

            return Products[index];
        }

        public static String[] loadString(String id)
        {
            String[] result = new string[Columns];

            result[0] = load(id).Id;
            result[1] = load(id).Name;
            result[2] = load(id).Quantity;
            result[3] = load(id).Price;
            result[4] = load(id).Description;
            result[5] = load(id).TypeProduct.ToString();

            return result;
        }

        public static String[,] loadStrings()
        {
            String[,] result = new string[Products.Count, Columns];
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

        public static String[] nameColumns()
        {
            String[] result = new string[Columns];
            result[0] = "Id";
            result[1] = "Nombre";
            result[2] = "Cantidad";
            result[3] = "Precio";
            result[4] = "Descripción";
            result[5] = "Tipo";

            return result;
        }

    }
}
