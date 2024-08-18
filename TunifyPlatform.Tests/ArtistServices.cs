using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Services;
using Microsoft.EntityFrameworkCore;

public class ArtistServicesTests
{
    private readonly Mock<TunifyDbContext> _mockContext;
    private readonly ArtistServices _artistService;

    public ArtistServicesTests()
    {
        _mockContext = new Mock<TunifyDbContext>(new DbContextOptions<TunifyDbContext>());
        _artistService = new ArtistServices(_mockContext.Object);
    }

    [Fact]
    public async Task CreateArtists_ShouldAddArtist()
    {
        // Arrange
        var artist = new Artist { ArtistId = 1, Name = "Artist1", Bio = "Bio1" };

        _mockContext.Setup(x => x.Artists.Add(It.IsAny<Artist>())).Verifiable();

        // Act
        var result = await _artistService.CreateArtists(artist);

        // Assert
        _mockContext.Verify(x => x.Artists.Add(It.IsAny<Artist>()), Times.Once);
        _mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        Assert.Equal(artist, result);
    }

    [Fact]
    public async Task GetAllArtists_ShouldReturnAllArtists()
    {
        // Arrange
        var artists = new List<Artist>
        {
            new Artist { ArtistId = 1, Name = "Artist1", Bio = "Bio1" },
            new Artist { ArtistId = 2, Name = "Artist2", Bio = "Bio2" }
        }.AsQueryable();

        _mockContext.Setup(x => x.Artists).ReturnsDbSet(artists);

        // Act
        var result = await _artistService.GetAllArtists();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Artist1", result[0].Name);
    }

    [Fact]
    public async Task GetArtistsById_ShouldReturnArtist()
    {
        // Arrange
        var artist = new Artist { ArtistId = 1, Name = "Artist1", Bio = "Bio1" };

        _mockContext.Setup(x => x.Artists.FindAsync(It.IsAny<int>())).ReturnsAsync(artist);

        // Act
        var result = await _artistService.GetArtistsById(1);

        // Assert
        Assert.Equal(artist, result);
    }

  
}
