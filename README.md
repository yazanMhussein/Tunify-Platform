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

Attributes: PlaylistSongID, PlaylistID, SongID
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