# Live-Project
The Live Project repository highlights stories I worked on for a Blue Ribbons Review site where users could write product reviews 
they purchased on Amazon. I used C# code and worked in ASP.NET MVC to accomplish the tasks.

Story1: AdminController.cs, AdminViewModel.cs, Index.cshtml
I created a controller that displayed the properties in the AdminViewModel for each application user in the database. 
This populated the data onto the Index View. In Visual Studio, I created an Index View of type "List" in the Admin Views folder. 
I then used the AdminViewModel as the data source and built out an AdminController that would iterate through(line 19) the properties in the AdminView Model to display information in the Index View from the database.

Story2: ReviewsController.cs, Details.cshtml
This story involved adding a link at the bottom of the Campaigns Index page. On the webpage, when a user clicks on a product, a link at the bottom takes them to a review site and allows them to write a review. In Visual Studio, I created an HTML.ActionLink(line 29) that users clicked on to be taken to the Create page in the Reviews Controller (Line 52). 

Story3:CampaignsController.cs
In this story I modified the SellerIndex of the CampaignsController.cs to diplay campaigns where the UserId equals that of users currently logged on and not those that are static UserId. When the user inputed their information their data would populate into the database.

Story4:Review.cs
In this story, I modified the Review class in the models folder in Visual Studio. I replaced the BuyerId with UserId and the Buyer Virtual navigation property with ApplicationUser. Making these changes simplified simplified the data structures and how the application interacted with Oauth.


