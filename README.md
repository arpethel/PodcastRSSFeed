# Podcast-RSS-Feed

Create an XML 

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

	services.AddDbContext<ApplicationDbContext>(options =>
	    options.UseSqlServer(
	        Configuration.GetConnectionString("DefaultConnection")));

Make sure to include the connection string to your database in appsettings.json as shown in the screenshot below:



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

[ApplicationDbContext]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/AddInboundPortRule.JPG
[AddSqlLogin]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/AddSqlLogin.JPG
[CreateVM]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/CreateVM.JPG
[DbMapping]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/DbMapping.JPG
[EnableSqlAuthentication]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/EnableSqlAuthentication.png
[EnableTCPIP]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/EnableTCPIP.JPG
[EnableTCPPorts]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/EnableTCPPorts.JPG
[RDP]: https://raw.githubusercontent.com/uid100/Deploy-SQLServer-on-Azure-VM/master/RDP.JPG

