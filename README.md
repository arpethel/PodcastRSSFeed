# Podcast-RSS-Feed

Create an ASP.NET MVC application that can be used to host a podcast.  Your application should allow users to create a podcast and add episodes to their podcast.  Your MVC application should contain an action method which returns an RSS feed in XML format from the entities in your SQL Database.

-----

## Step 1.

### Create an ASP.NET MVC application

Starup Visual studio and create a new ASP.NET MVC application.  Install the package for Microsoft.EntityFrameworkCore.Tools via the NuGet Package manager or by executing the command below:

  Install-Package Microsoft.EntityFrameworkCore.Tools

-----

## Step 2.

### Decode the RSS XML & create the model

Define the properties required to properly abstract a podcast and a podcast episode.  Create the Podcast and PodcastEpisode classes in the Models folder of your project.  The podcast should contain a generic collection member of type ICollection<PodcastEpisode>.  See the example podcast RSS file in the link below.

https://help.apple.com/itc/podcasts_connect/#/itc1723472cb

Create the ApplicationDbContext class in the Models folder.  The ApplicationDbContext class must inherit from the DbContext class, contain one contructor with an input parameter called options of type DbContextOptions<ApplicationDbContext> and call the base method's constructor with the options value as input.  

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

Finally add the Podcast and PostcastEpisode DbSet properties to the ApplicationDbContext class.

  public DbSet<Podcast> Podcasts { get; set; }
  public DbSet<PodcastEpisode> PodcastEpisodes { get; set; }

![ApplicationDbContext][ApplicationDbContext]

-----

## Step 4.

### Update Startup.cs & appsettings.json

Add the database to the application services by adding the DbContext of your ApplicationDbContext.  Make sure to configure your database to use SqlServer based off a configuration string with the key "DefaultConnection".

![ConfigureServices][ConfigureServices]

Make sure to include the connection string to your database in appsettings.json as shown in the screenshot below:

![AppSettingsJson][AppSettingsJson]

-----

## Step 5.

### Migrate the database

Migrate the database to SQL Server by executing the commands below:

  Add-Migration InitialCreate
  
  Update-Database
  

### Scaffold the controllers

Add an MP3 file such as the Windows95.mp3 file in this repository to the wwwroot directory.  Scaffold the controllers with views then run the app and create a single podcast with 2 episodes for that podcast.  Make sure the URL for the PodcastEpisode is an MP3 file from wwwroot.
  
-----

## Step 6.

### Generate an RSS XML string

Create a new action method in the PodcastController called RSSFeed that queries the pocast database and returns a string containing the Podcast RSS XML. 

-----

[ApplicationDbContext]: https://raw.githubusercontent.com/MicroJEdi/AzureFunctionPodcastRSS/master/DbContext.png
[AppSettingsJson]: https://raw.githubusercontent.com/MicroJEdi/AzureFunctionPodcastRSS/master/AppSettingsJson.png
[ConfigureServices]: https://raw.githubusercontent.com/MicroJEdi/AzureFunctionPodcastRSS/master/ConfigureServices.png
