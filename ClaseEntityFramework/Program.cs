using ClaseEntityFramework;

using var db = new EjemploDBContext();

// db.Products.Add(new Product{
//     Name = "Foo",
//     Price = 200.30M,
//     Stock = 25
// });

// db.Products.Add(new Product{
//     Name = "Bar",
//     Price = 120M,
//     Stock = 13
// });
db.Products.Add(new Product{
    Name = "FooBar",
    Price = 120M,
    Stock = 12
});

//Guardar
//db.SaveChanges();
EfEjercicios.CrearProductCategoria();
var listProduct = db.Products.Select(x => x.Name);

// foreach (var item in listProduct)
// {
//     System.Console.WriteLine(item);
// }

var listProductCategory = db.ProductCategories.Select(x => x.Name);

foreach (var item in listProductCategory)
{
    System.Console.WriteLine(item);
}


await EfEjerciciosRepositorios.RepositoryClient();

