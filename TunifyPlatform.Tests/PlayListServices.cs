using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Services;
using Microsoft.EntityFrameworkCore;

public class PlayListServicesTests
{
    private readonly Mock<TunifyDbContext> _mockContext;
    private readonly PlayListServices _playListService;

    public PlayListServicesTests()
    {
        _mockContext = new Mock<TunifyDbContext>(new DbContextOptions<TunifyDbContext>());
        _playListService = new PlayListServices(_mockContext.Object);
    }

    [Fact]
    public async Task CreatePlayList_ShouldAddPlayList()
    {
        // Arrange
        var playList = new PlayList { PlaylistId = 1, PlaylistName = "Playlist1" };

        _mockContext.Setup(x => x.Playlists.Add(It.IsAny<PlayList>())).Verifiable();

        // Act
        var result = await _playListService.CreatePlayList(playList);

        // Assert
        _mockContext.Verify(x => x.Playlists.Add(It.IsAny<PlayList>()), Times.Once);
        _mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        Assert.Equal(playList, result);
    }

    [Fact]
    public async Task GetAllPlayList_ShouldReturnAllPlayLists()
    {
        // Arrange
        var playLists = new List<PlayList>
        {
            new PlayList { PlaylistId = 1, PlaylistName = "Playlist1" },
            new PlayList { PlaylistId = 2, PlaylistName = "Playlist2" }
        }.AsQueryable();

        _mockContext.Setup(x => x.Playlists).ReturnsDbSet(playLists);

        // Act
        var result = await _playListService.GetAllPlayList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Playlist1", result[0].PlaylistName);
    }

    [Fact]
    public async Task GetPlayListById_ShouldReturnPlayList()
    {
        // Arrange
        var playList = new PlayList { PlaylistId = 1, PlaylistName = "Playlist1" };

        _mockContext.Setup(x => x.Playlists.FindAsync(It.IsAny<int>())).ReturnsAsync(playList);

        // Act
        var result = await _playListService.GetPlayListById(1);

        // Assert
        Assert.Equal(playList, result);
    }

    // Add more tests for UpdatePlayList, DeletePlayList, and AddSongToPlaylist as needed
}
