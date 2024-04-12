// See https://aka.ms/new-console-template for more information

// Ingredient class to represent ingredients in a recipe
public class Ingredient
{
    public string Name { get; set; } // Name of the ingredient
    public int Quantity { get; set; } // Quantity of the ingredient
    public int OriginalQuantity { get; set; } // Original quantity of the ingredient
    public string UnitOfMeasurement { get; set; } // Unit of measurement for the ingredient
}

// Step class to represent steps in a recipe
public class Step
{
    // Description of the step 
    public string Description { get; set; }
}

// Recipe class to represent a recipe
public class Recipe
{
    public string RecipeName { get; set; } // Name of the recipe
    public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe
    public List<Step> Steps { get; set; } // List of steps in the recipe

    // Constructor to initialize a new recipe with the given name
    public Recipe(string recipeName)
    {
        RecipeName = recipeName;
        Ingredients = new List<Ingredient>(); // Initialize the list of ingredients
        Steps = new List<Step>(); // Initialize the list of steps
    }

    // Method to add an ingredient to the recipe
    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient); // Add the ingredient to the list of ingredients
    }

    // Method to add a step to the recipe
    public void AddStep(Step step)
    {
        // Add the step to the list of steps
        Steps.Add(step);
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("***********************************");
        Console.WriteLine($"Recipe Name: {RecipeName}");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.UnitOfMeasurement}");
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i].Description}");
        }
        Console.WriteLine("***********************************");
    }

    // Method to scale the recipe by a given factor
    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = (int)(ingredient.OriginalQuantity * factor); // Scale the quantity of each ingredient
        }
    }

    // Method to reset the recipe to its original quantities
    public void ResetRecipe()
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = ingredient.OriginalQuantity; // Reset the quantity of each ingredient
        }
    }
}

// Main program class
public class Program
{
    static void Main(string[] args)
    {
        // Initialize the recipe variable
        Recipe recipe = null; // Initialize the recipe variable

        while (true) // Loop for menu-driven interaction
        {
            // Display the menu options
            Console.WriteLine("***********************************");
            Console.WriteLine("Welcome To Your Recipe Application");
            Console.WriteLine("***********************************");
            Console.WriteLine("1. Enter new recipe");
            Console.WriteLine("2. Display recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset recipe");
            Console.WriteLine("5. Clear recipe data");
            Console.WriteLine("6. Exit Program");
            Console.WriteLine("***********************************");
            // Get user input for menu choice
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("INVALID CHOICE. PLEASE ENTER A VALID NUMBER.");
                continue;
            }

            switch (choice) // Handle user's choice
            {
                case 1:
                    // Enter a new recipe
                    Console.WriteLine("Enter recipe name: ");
                    string recipeName = Console.ReadLine();
                    recipe = new Recipe(recipeName);

                    Console.WriteLine("Enter number of ingredients: ");
                    int numIngredients;
                    if (!int.TryParse(Console.ReadLine(), out numIngredients))
                    {
                        Console.WriteLine("INVALID INPUT. PLEASE ENTER A VALID NUMBER.");
                        continue;
                    }

                    // Loop to input ingredients
                    for (int i = 0; i < numIngredients; i++)
                    {
                        var ingredient = new Ingredient();

                        Console.WriteLine($"Enter the name of ingredient {i + 1}: ");
                        ingredient.Name = Console.ReadLine();

                        Console.WriteLine($"Enter the quantity of {ingredient.Name}: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal Quantity))
                        {
                            Console.WriteLine("INVALID INPUT. PLEASE ENTER A VALID NUMBER.");
                            continue;
                        }
                        // Assign parsed quantity to ingredient.Quantity
                        ingredient.Quantity = (int)Quantity;
                        ingredient.OriginalQuantity = ingredient.Quantity;

                        Console.WriteLine($"Enter the unit of measurement for {ingredient.Name}: ");
                        ingredient.UnitOfMeasurement = Console.ReadLine();

                        recipe.AddIngredient(ingredient);
                    }

                    // Input steps for the recipe
                    Console.WriteLine("Enter number of steps: ");
                    int numSteps;
                    if (!int.TryParse(Console.ReadLine(), out numSteps))
                    {
                        Console.WriteLine("INVALID INPUT. PLEASE ENTER A VALID NUMBER.");
                        continue;
                    }

                    // Loop to input steps
                    for (int i = 0; i < numSteps; i++)
                    {
                        var step = new Step();

                        Console.WriteLine($"Enter step {i + 1}: ");
                        step.Description = Console.ReadLine();

                        recipe.AddStep(step);
                    }
                    break;

                case 2:
                    // Display the recipe
                    if (recipe == null)
                    {
                        Console.WriteLine("NO RECIPE ENTERED YET.");
                    }
                    else
                    {
                        recipe.DisplayRecipe();
                    }
                    break;

                case 3:
                    // Scale the recipe
                    if (recipe == null)
                    {
                        Console.WriteLine("NO RECIPE ENTERED YET.");
                    }
                    else
                    {
                        Console.WriteLine("Enter scaling factor (0.5, 2, or 3): ");
                        double factor;
                        if (!double.TryParse(Console.ReadLine(), out factor))
                        {
                            Console.WriteLine("INVALID INPUT. PLEASE ENTER A VALID NUMBER.");
                            continue;
                        }
                        recipe.ScaleRecipe(factor);
                        Console.WriteLine("Recipe scaled successfully.");
                    }
                    break;

                case 4:
                    // Reset the recipe
                    if (recipe == null)
                    {
                        Console.WriteLine("NO RECIPE ENTERED YET.");
                    }
                    else
                    {
                        recipe.ResetRecipe();
                        Console.WriteLine("Recipe reset to original values.");
                    }
                    break;

                case 5:
                    // Clear the recipe data
                    recipe = null;
                    Console.WriteLine("Recipe data cleared.");
                    break;

                case 6:
                    // Exit the program
                    Console.WriteLine("THANK YOU FOR USING THIS APPLICATION");
                    return;

                default:
                    Console.WriteLine("INVALID CHOICE. PLEASE ENTER A VALID NUMBER.");
                    break;
            }
        }
    }
}


