# Oefeningen : Hoofdstuk 7
## Entity Framework Core SportsStore 
> Bevat enkel de starter files, niet de effectieve VS Solution.

### Context 

In deze oefeningen les starten we met het bouwen van een online sportwinkel: `SportsStore`. In deze online winkel kunnen gebruikers de catalogus met sportartikelen `Product` raadplegen. Deze artikelen, die elk tot een bepaalde categorie `Category` behoren, kunnen ze in een winkelmandje `Cart` leggen. Uiteindelijk kunnen aangemelde klanten `Customer` de artikelen die in het winkelmandje liggen effectief bestellen `Order`. Hieronder vind je enkele screenshots die je een idee geven van de SportsStore.

#### Zoeken in de catalogus:
![Zoeken.png](https://webiii.github.io/portal/docs/H07/fig1.png "Zoeken")

#### De cart: 
![Cart.png](https://webiii.github.io/portal/docs/H07/fig2.png "Cart")

#### Het DCD:
![DCD.png](https://webiii.github.io/portal/docs/H07/fig3.png "DCD")

## Opgave 
In deze oefening maak je een nieuw project op basis van enkele reeds bestaande klassen. Deze vind je terug in deze repository.
### Aanmaken project 
  - Maak een nieuwe Console applicatie SportsStore aan en voeg toe aan source control
  - Voeg SQL Server database provider for Entity Framework Core toe en het Entity Framework Core tools package
  - Commit 
  
#### Klasse `ApplicationDbContext`
- Maak de persistentieklasse `ApplicationDbContext` aan in de Data folder 
- Configureer de Database Provider 
```cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
          var connectionstring =  @"Server=.;Database=SportsStore;Integrated Security=True;"; 
          optionsBuilder.UseSqlServer(connectionstring); 
        } 
```
- Pas program.cs aan zodat de database telkens opnieuw gecreëerd wordt 
- Run, controleer of database werd aangemaakt 
- Commit

#### Klasse `Product`
- Maak de `Models` folder aan; 
- Voeg de klasse `Product` toe. (zie Models folder in deze repository)
- Deze klasse moet als de image hieronder gemapt worden;
- De naam van de tabel is `Product`.
- Voeg de volgende items toe:
  - `DbSet(s)`
  - Mapping via Fluent API 
- Build het project. 
- Run en controleer of de database `SportsStore` is aangemaakt en tabel `Product` bovenstaande kolommen bevat.  
- Commit “Add class Product and mapping”

| PK  | Column Name | Data Type     | Allows NULL |
| --- | ----------- | ------------- | ----------- |
| X   | ProductId   | int           | No          |
|     | Description | nvarchar(max) | Yes         |
|     | Name        | nvarchar(100) | No          |
|     | Price       | decimal(18,2) | No          |

#### Klasse `City` 
- Voeg de klasse `City` toe.  
- Map de klasse naar de tabel `City`
- Run en controleer de database. 
- Commit “Add class City and mapping”

| PK  | Column Name | Data Type     | Allows NULL |
| --- | ----------- | ------------- | ----------- |
| X   | PostalCode  | nvarchar(5)   | No          |
|     | Name        | nvarchar(100) | No          |

#### Klasse `Customer` 
- Voeg de klasse `Customer` toe.  
- Map de klasse en associatie met `City` (geen cascading delete) 
- Run en controleer de database. 
- Commit “Add class Customer and mapping”

| PK  | Column Name    | Data Type     | Allows NULL |
| --- | -------------- | ------------- | ----------- |
| X   | CustomerId     | int           | No          |
|     | CityPostalCode | nvarchar(5)   | No          |
|     | CustomerName   | nvarchar(20)  | No          |
|     | FirstName      | nvarchar(100) | No          |
|     | Name           | nvarchar(100) | No          |
|     | Street         | nvarchar(100) | Yes         |

#### Klasse Cart en CartLine 
- Voeg de klassen Cart en CartLine toe. 
- Deze klassen mogen niet in de database worden opgenomen. 
- Waarom nemen we deze klassen niet op in de database?
- Run en controleer de database. 
- Commit 

#### Klasse `Order` en `Orderline`
- Voeg de klassen `Order` en `OrderLine` toe.  
- Verwijder de commentaar uit de klasse `Customer`, zodat Customer nu zijn `Orders` kent. 
- Map de klassen en associaties. Denk na over de cascading. Een `Order` verwijderen, verwijdert ook de `OrderLines`. Een `product` verwijderen kan enkel als het in geen enkel `order` voorkomt. `
- Je hoeft geen `DbSet` te voorzien voor `Order` en `OrderLine` in de klasse `ApplicationDbContext`. Waarom niet? 
- De database ziet er als volgt uit. Genereer het database diagram in Sql Server Management Studio  
![DB.png](https://webiii.github.io/portal/docs/H07/fig4.png "DB")
- Commit

#### Vervolledig de methodes in de domeinklassen 
Vervolledig onderstaande methodes in de domeinklasse `Order` en `Cart`. Voor deze methodes zijn reeds testen voorzien. Maak eerst een test project aan en voeg de testklassen `OrderTest` en `CartTest` toe aan de `Models` folder. Run de testen, een aantal falen. Implementeer dan onderstaande properties/methodes:
- `Cart` : `AddLine`. Deze methode voegt een `product` toe aan de `Cart`. Pas deze methode aan. Als product al aanwezig in `cart` wordt het aantal met het opgegeven aantal verhoogd.  
- `Order` : Property `Total`  = de som van de producten in de `OrderLines (aantal * prijs)` 
- `Order` : Methode `HasOrderedProduct`. Deze methode gaat na of dit product werd besteld. Maak gebruik van de `Equals` methode van `Product`. Bekijk de implementatie. 2 producten zijn gelijk als ze eenzelfde `productId` hebben.  
- Run de testen. Alle testen moeten slagen. 
- Commit
