using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItLabs.MyRecipes.Data.Repository;
using ItLabs.MyRecipes.Core.Responses;
using ItLabs.MyRecipes.Core.Requests;
// <copyright file="RecipeManagerTest.SearchRecipes.g.cs">Copyright ©  2016</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace ItLabs.MyRecipes.Core.Managers.Tests
{
    public partial class RecipeManagerTest
    {

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
public void SearchRecipes677()
{
    RecipeManager recipeManager;
    SearchRequest searchRequest;
    SearchResponse searchResponse;
    recipeManager =
      new RecipeManager(null, null);
    searchRequest = new SearchRequest();
    searchRequest.Name = "";
    searchRequest.IsDone = false;
    searchRequest.IsFavorite = false;
    searchResponse = this.SearchRecipes(recipeManager, searchRequest);
    Assert.IsNotNull((object)searchResponse);
    Assert.IsNull(searchResponse.Recipes);
    Assert.AreEqual<bool>(false, searchResponse.IsSuccessful);
    Assert.IsNotNull(((ResponseBase)searchResponse).Errors);
    Assert.AreEqual<int>(4, ((ResponseBase)searchResponse).Errors.Capacity);
    Assert.AreEqual<int>(1, ((ResponseBase)searchResponse).Errors.Count);
    Assert.IsNotNull((object)recipeManager);
    Assert.IsNull(recipeManager._recipeRepository);
    Assert.IsNull(recipeManager._ingredientRepository);
}

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
public void SearchRecipes49()
{
    RecipeManager recipeManager;
    SearchRequest searchRequest;
    SearchResponse searchResponse;
    recipeManager =
      new RecipeManager(null, (IIngredientRepository)null);
    searchRequest = new SearchRequest();
    searchRequest.Name = new string('\0', 51);
    searchRequest.IsDone = false;
    searchRequest.IsFavorite = false;
    searchResponse = this.SearchRecipes(recipeManager, searchRequest);
    Assert.IsNotNull((object)searchResponse);
    Assert.IsNull(searchResponse.Recipes);
    Assert.AreEqual<bool>(false, ((ResponseBase)searchResponse).IsSuccessful);
    Assert.IsNotNull(((ResponseBase)searchResponse).Errors);
    Assert.AreEqual<int>(4, searchResponse.Errors.Capacity);
    Assert.AreEqual<int>(2, ((ResponseBase)searchResponse).Errors.Count);
    Assert.IsNotNull((object)recipeManager);
    Assert.IsNull(recipeManager._recipeRepository);
    Assert.IsNull(recipeManager._ingredientRepository);
}

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SearchRecipesThrowsNullReferenceException190()
{
    RecipeManager recipeManager;
    SearchRequest searchRequest;
    SearchResponse searchResponse;
    recipeManager =
      new RecipeManager((IRecipeRepository)null, (IIngredientRepository)null);
    searchRequest = new SearchRequest();
    searchRequest.Name = (string)null;
    searchRequest.IsDone = false;
    searchRequest.IsFavorite = false;
    searchResponse = this.SearchRecipes(recipeManager, searchRequest);
}

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SearchRecipesThrowsNullReferenceException212()
{
    RecipeManager recipeManager;
    SearchRequest searchRequest;
    SearchResponse searchResponse;
    recipeManager =
      new RecipeManager((IRecipeRepository)null, (IIngredientRepository)null);
    searchRequest = new SearchRequest();
    searchRequest.Name = " ";
    searchRequest.IsDone = false;
    searchRequest.IsFavorite = false;
    searchResponse = this.SearchRecipes(recipeManager, searchRequest);
}

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void SearchRecipes01()
{
    RecipeRepository recipeRepository;
    RecipeManager recipeManager;
    SearchResponse searchResponse;
    recipeRepository = new RecipeRepository();
    recipeManager = new RecipeManager
                        ((IRecipeRepository)recipeRepository, (IIngredientRepository)null);
    searchResponse = this.SearchRecipes(recipeManager, (SearchRequest)null);
}

[TestMethod]
[PexGeneratedBy(typeof(RecipeManagerTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void SearchRecipesThrowsNullReferenceException221()
{
    RecipeManager recipeManager;
    SearchResponse searchResponse;
    recipeManager =
      new RecipeManager((IRecipeRepository)null, (IIngredientRepository)null);
    searchResponse = this.SearchRecipes(recipeManager, (SearchRequest)null);
}
    }
}
