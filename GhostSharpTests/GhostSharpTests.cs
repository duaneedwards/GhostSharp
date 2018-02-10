using GhostSharp;
using GhostSharp.Entities;
using Xunit;

namespace GhostSharpTests
{
    public partial class GhostSharpTests
    {
        [Fact]
        public void GetAuthToken_ReturnsToken_WhenCredentialsValid()
        {
            var auth = new GhostAPI(Url, ClientId, ClientSecret);

            AuthToken token = auth.GetAuthToken(UserName, Password, ClientId, ClientSecret);
       
            Assert.NotNull(token.AccessToken);
            Assert.NotEmpty(token.AccessToken);
            Assert.NotNull(token.RefreshToken);
            Assert.NotEmpty(token.RefreshToken);

            Assert.Equal(2628000, token.ExpiresIn);
            Assert.Equal("Bearer", token.TokenType);
        }

        [Fact]
        public void GetPages_ReturnsAllPages_UsingClientSecret()
        {
            var auth = new GhostAPI(Url, ClientId, ClientSecret);

            var posts = auth.GetPosts();

            Assert.Equal(2, posts.Count);
        }

        [Fact]
        public void GetPages_ReturnsAllPages_WhenAuthTokenValid()
        {
            var auth = new GhostAPI(Url, AuthToken);

            var pages = auth.GetPages();

            Assert.Equal(3, pages.Count);
            Assert.Equal("License", pages[0].Title);
        }
    }
}
