using BookShop.Controllers;
using BookShop.ViewModels;
using BookShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopTests.Controllers
{
    public class BookControllerTests
    {
        [Fact]
        public void List_EmptyGenre_ReturnAllBooks()
        {
            //arrange
            var mockBookRepo = RepositoryMocks.getBookRepository();
            var mockGenreRepo = RepositoryMocks.getGenreRepository();
            var bookController = new BookController(mockBookRepo.Object, mockGenreRepo.Object);
            //act
            var reuslt = bookController.List("");
            //assert
            var viewResult = Assert.IsType<ViewResult>(reuslt);
            var bookListViewModel = Assert.IsAssignableFrom<BookListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, bookListViewModel.Books.Count());
        }
    }
}
