using Microsoft.EntityFrameworkCore;
using AlbumAPI.Data;
using AlbumAPI.Model;
namespace AlbumAPI;

public static class AlbumModelEndpoints
{
    public static void MapAlbumModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/AlbumModel", async (AlbumAPIContext db) =>
        {
            return await db.AlbumModel.ToListAsync();
        })
        .WithName("GetAllAlbumModels");

        routes.MapGet("/api/AlbumModel/{id}", async (int Id, AlbumAPIContext db) =>
        {
            return await db.AlbumModel.FindAsync(Id)
                is AlbumModel model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetAlbumModelById");

        #region ModificationCode
        //routes.MapPut("/api/AlbumModel/{id}", async (int Id, AlbumModel albumModel, AlbumAPIContext db) =>
        //{
        //    var foundModel = await db.AlbumModel.FindAsync(Id);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }
        //    //update model properties here

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateAlbumModel");

        //routes.MapPost("/api/AlbumModel/", async (AlbumModel albumModel, AlbumAPIContext db) =>
        //{
        //    db.AlbumModel.Add(albumModel);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/AlbumModels/{albumModel.Id}", albumModel);
        //})
        //.WithName("CreateAlbumModel");

        //routes.MapDelete("/api/AlbumModel/{id}", async (int Id, AlbumAPIContext db) =>
        //{
        //    if (await db.AlbumModel.FindAsync(Id) is AlbumModel albumModel)
        //    {
        //        db.AlbumModel.Remove(albumModel);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(albumModel);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteAlbumModel");
        #endregion
    }
}
