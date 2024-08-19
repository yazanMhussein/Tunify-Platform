# TunifyPlatform

# Introduction
Welcome to Tunify—a dynamic web app designed to enhance the experience of music lovers. 
Users can, using Tunify, search across its huge collection of songs and create their own playlists.
With this, manage subscriptions that make your life simpler. Whether you are an artist eager to share your song or a listener in the quest for new tunes, 
Tunify is always there to help you with its hassle-free and engaging platform for all your musical needs.
![Tunify](Tunify.png)

# Detailed Relationships
## User and Subscription: A user subscribes to one of the provided subscription plans, which define the degree of access that users have to the functionality of the application.
## User and Playlist: The user can have several playlists that include a number of songs.
## Artist and Album: An artist can release several albums that include a number of songs.
## Artist and Song: An artist can have several songs, which may be included in different albums.
## Album and Song: Each album includes a number of songs, and each song is associated with one album.
## Playlist and PlaylistSong: Playlists are collections of songs. This many-to-many relationship is handled through the PlaylistSong entity joining the songs to the playlists.

# Overview of Entity Relationships
# Tunify's database is structured to efficiently manage and relate various entities such as Users, Artists, Albums, Songs, Playlists, and Subscriptions. Below is an overview of the relationships between these entities:

Entities and Their Relationships
User

Attributes: UserID, Username, Email, JoinDate, SubscriptionID
Relationships:
A User has one Subscription.
A User can have multiple Playlists.
Subscription

Attributes: SubscriptionID, SubscriptionType, Price
Relationships:
A Subscription can have multiple Users.
Artist

Attributes: ArtistID, Name, Bio
Relationships:
An Artist can have multiple Albums.
An Artist can have multiple Songs.
Album

Attributes: AlbumID, AlbumName, ReleaseDate, ArtistID
Relationships:
An Album belongs to one Artist.
An Album can have multiple Songs.
Song

Attributes: SongID, Title, ArtistID, AlbumID, Duration, Genre
Relationships:
A Song belongs to one Artist.
A Song belongs to one Album.
A Song can be part of multiple PlaylistSongs.
Playlist

Attributes: PlaylistID, UserID, PlaylistName, CreatedDate
Relationships:
A Playlist belongs to one User.
A Playlist can have multiple PlaylistSongs.
PlaylistSong

Attributes: 
PlaylistSongID, PlaylistID, SongID
Relationships:
A PlaylistSong belongs to one Playlist.
A PlaylistSong belongs to one Song.

# Repository Design Pattern

 The Repository Design Pattern that mediates data to and from the database using collections of objects. 
 It provides a more object-oriented way to get access and manipulate data. A need was felt for abstraction 
 from the data access layer to the business logic layer.

# Benefits of the Repository Design Pattern

Separation of Concerns: 
The Repository Design Pattern helps in cleaning the code base and makes it maintainable, separating data access logic from business logic.
Testability:
This facilitates mocking repositories for unit testing, hence improving testability.
Flexibility:
This makes it easy to replace the sources of data without changing the business logic. For example, you can change from a SQL database to a NoSQL database with very few changes.
It has centralized data access logic, whereby every data access logic is kept in one place. This makes maintenance and update of the same easy to do.
Reusability:
It enables sharing of common data access code across different parts of the application.

## New Navigation and Routing Functionalities

In this update, we have implemented new navigation and routing functionalities within the Tunify Platform:

### Playlist and Song Relationship

- **Navigation**: Users can now navigate between playlists and the songs they contain. This functionality allows users to view details of playlists and manage the songs within them.
- **Routing**: New API endpoints and routing logic have been added to support these functionalities. Users can view a playlist, add new songs, or remove existing ones.

### Artist and Song Relationship

- **Navigation**: Users can now navigate between artists and their songs. This feature allows users to view an artist's profile and manage their songs.
- **Routing**: Additional API endpoints and routing logic support this feature, enabling users to view an artist's details and manage their songs.

For detailed information on the new routes and how to use these features, refer to the API documentation or the corresponding sections in the application.

## Addition of Swagger UI

In this update, we have integrated Swagger UI into the Tunify Platform to provide comprehensive API documentation and testing capabilities:

### Swagger Setup

- **Integration**: Swagger UI has been added using the Swashbuckle.AspNetCore package. This tool automatically generates interactive API documentation.
- **Configuration**: The Swagger services are configured in the `Program.cs` file using `AddSwaggerGen`, and the Swagger middleware is added with `UseSwagger` and `UseSwaggerUI`.

### Accessing and Using Swagger UI

1. **Access Swagger UI**:
   - Launch the application.
   - Navigate to the root URL or the `/swagger` endpoint in your web browser to access the Swagger UI.

2. **Using Swagger UI**:
   - **Explore Endpoints**: Use the Swagger UI to view all available API endpoints. Each endpoint is documented with details on the request and response formats.
   - **Testing API**: You can interact with the API directly from Swagger UI by sending requests and viewing responses.
   - **Authentication**: If your API requires authentication, Swagger UI supports configuring the necessary credentials.

For more details on using Swagger UI or specific examples, refer to the interactive documentation provided.


# Implementation in Tunify 

In the Tunify Web App responsible for data access to all entities, which involves Users, Artists, Albums, Songs, Playlists, and Subscriptions. 
Each repository provides methods to realize CRUD operations and abstracts underlying database interactions.

# Getting Started
To get started with Tunify, follow these steps:

Clone the Repository:

Copy code
git clone https://github.com/yourusername/tunify.git
Navigate to the Project Directory:

cd tunify
Set Up the Database: Ensure you have a SQL Server instance running and update the connection string in appsettings.json.

Run the Application: Use your preferred IDE to build and run the application.