using Microsoft.EntityFrameworkCore;

namespace ClaseEntityFramework;

public static class EfEjerciciosRepositorios
{

    public static async Task BasicoAsync()
    {

        using var db = new EjemploDBContext();

        var unitOfWork = db as IUnitOfWork;

        Console.WriteLine($"Database path: {db.DbPath}.");

        var productRepository = new ProductRepository(db);
        var productCategoryRepository = new ProductCategoryRepository(db);

        var random = new Random();
        var numero = random.Next(0, 100);

        //Verificar si existe categoria
        var productCategory = await productCategoryRepository.GetByIdAsync(numero);
        if (productCategory == null)
        {

            productCategory = new ProductCategory();
            productCategory.Id = numero;
            productCategory.Name = "Categoria_" + numero;

            await productCategoryRepository.AddAsync(productCategory);

        }

        var product = new Product
        {
            Name = $"Foo_Repositorio_{numero}",
            Price = 200.30M,
            Stock = 35,
            ProductCategory = productCategory
        };

        await productRepository.AddAsync(product);

        await unitOfWork.SaveChangesAsync();



        var listProduct = productRepository.GetAllIncluding(x => x.ProductCategory);


        foreach (var productItem in listProduct)
        {
            Console.WriteLine($"Categoria: {productItem.ProductCategory.Name}. Id: {productItem.ProductCategory.Id}");
            Console.WriteLine(productItem);
        }


    }

    public static async Task RepositoryClient()
    {
        using var db = new EjemploDBContext();
        var unitOfWork = db as IUnitOfWork;
        Console.WriteLine($"Database path: {db.DbPath}.");

        var clientRepository = new ClientRepository(db);
        var client = new Client
        {
            Name = "Diego Marquez",

        };
        var client2 = new Client
        {
            Name = "Daniela Marquez",

        };
        var client3 = new Client
        {
            Name = "Mario Marquez",

        };

        await clientRepository.AddAsync(client);
        await clientRepository.AddAsync(client2);
        await clientRepository.AddAsync(client3);

        await unitOfWork.SaveChangesAsync();

        var listClient = clientRepository.GetAll();
        foreach (var item in listClient)
        {
            System.Console.WriteLine($"El cliente: {item.Name} tiene una id: {item.Id}");
        }
    }
    public static async Task ElimnarTodoAsync()
    {

        using var db = new EjemploDBContext();

        var unitOfWork = db as IUnitOfWork;

        Console.WriteLine($"Database path: {db.DbPath}.");

        var productRepository = new ProductRepository(db);
        var listProduct = productRepository.GetAll();

        Console.WriteLine("Eliminar todos los productos");

        foreach (var productItem in listProduct)
        {
            Console.WriteLine(productItem);

            productRepository.Delete(productItem);
        }

        await unitOfWork.SaveChangesAsync();

    }
}