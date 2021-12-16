using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos
{
    public class ProductController
    {
        private static List<Product> products = new List<Product>();
        private static int index = 0;


        public static bool save(Product product) 
        {
            bool exist = false;
            bool saved = false;

            products.ForEach(p => { if (p.Id == product.Id) exist = true; });

            if (!exist)
            {
                products.Add(product);
                saved = true;
            }
            return saved;
        }

        public static bool update(Product product)
        {
            bool saved = false;

            products.ForEach(p =>
            {
                if (p.Id == product.Id)
                {
                    p = product;
                    saved = true;
                }
            });

            return saved;
        }

        public static bool delete(Product product)
        {
            bool deleted = false;

            products.ForEach(p =>
            {
                if (p.Id == product.Id)
                {
                    products.Remove(p);
                    deleted = true;
                }
            });

            return deleted;
        }

        public static Product load(String id)
        {
            Product product = null;
            products.ForEach(p =>
            {
                if (p.Id == id)
                    product = p;
            });

            return product;
        }

        public static bool HasNext()
        {
            bool HasNext;
            Product product = products[index + 1];

            if (product != null)
                HasNext = true;
            else
                HasNext = false;

            return HasNext;
        }

        public static Product next()
        {
            index++;
            return products[index];
        }

        public static Product last()
        {
            index = products.Count - 1;

            return products[index];
        }

        public static Product first()
        {
            index = 0;

            return products[index];
        }

    }
}
