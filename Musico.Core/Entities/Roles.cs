namespace Musico.Core.Entities;

public enum Roles
{
    Viewer = 1,        // Can view content
    Publisher = 2,     // Can publish content
    Editor = 4,        // Can edit content
    Banner = 8,        // Can manage banners
    Moderator = 16,    // Can moderate content

    Admin = Viewer | Publisher | Editor | Banner | Moderator // Full access
}