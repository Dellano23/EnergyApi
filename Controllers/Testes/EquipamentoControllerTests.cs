using AutoMapper;
using Fiap.Api.Energy.Controllers;
using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.Services;
using Fiap.Api.Energy.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Tests
{
    public class EquipamentoControllerTests
    {
        private readonly Mock<IEquipamentoService> _serviceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EquipamentoController _controller;

        public EquipamentoControllerTests()
        {
            _serviceMock = new Mock<IEquipamentoService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new EquipamentoController(_serviceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Post_ValidEquipamentoCreateViewModel_ReturnsCreated()
        {
            // Arrange
            var createViewModel = new EquipamentoCreateViewModel
            {
                EquipamentoNome = "Equip1"
                // Adicione outros campos aqui se a sua classe CreateViewModel exigir
                // Potencia = 10,
                // UsoMinutoDia = 30
            };

            // O controller passa o CreateViewModel direto para o serviço, sem AutoMapper neste ponto
            _serviceMock.Setup(s => s.CriarEquipamento(createViewModel));

            // Act
            var result = _controller.Post(createViewModel);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
            Assert.Equal(createViewModel, statusCodeResult.Value);

            _serviceMock.Verify(s => s.CriarEquipamento(createViewModel), Times.Once);
        }

        [Fact]
        public void Put_ExistingEquipamento_UpdatesAndReturnsNoContent()
        {
            // Arrange
            int equipamentoId = 1;

            var viewModel = new EquipamentoViewModel
            {
                EquipamentoNome = "Equip1 Updated"
            };

            var existingModel = new EquipamentoModel
            {
                EquipamentoId = equipamentoId,
                EquipamentoNome = "Equip1"
            };

            _serviceMock.Setup(s => s.ObterEquipamentoPorId(equipamentoId)).Returns(existingModel);
            _mapperMock.Setup(m => m.Map(viewModel, existingModel));
            _serviceMock.Setup(s => s.AtualizarEquipamento(existingModel)); 

            // Act
            var result = _controller.Put(equipamentoId, viewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _serviceMock.Verify(s => s.ObterEquipamentoPorId(equipamentoId), Times.Once);
            _mapperMock.Verify(m => m.Map(viewModel, existingModel), Times.Once);
            _serviceMock.Verify(s => s.AtualizarEquipamento(existingModel), Times.Once);
        }

        [Fact]
        public void Put_NonExistingEquipamento_ReturnsNotFound()
        {
            // Arrange
            int equipamentoId = 99;
            var viewModel = new EquipamentoViewModel();

            // Correção do aviso CS8600/CS8625 de conversão nula: adicionado o "?"
            _serviceMock.Setup(s => s.ObterEquipamentoPorId(equipamentoId)).Returns((EquipamentoModel?)null);

            // Act
            var result = _controller.Put(equipamentoId, viewModel);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _serviceMock.Verify(s => s.ObterEquipamentoPorId(equipamentoId), Times.Once);
            _mapperMock.Verify(m => m.Map(It.IsAny<EquipamentoViewModel>(), It.IsAny<EquipamentoModel>()), Times.Never);
            _serviceMock.Verify(s => s.AtualizarEquipamento(It.IsAny<EquipamentoModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallsServiceDeleteAndReturnsNoContent()
        {
            // Arrange
            int equipamentoId = 1;
            _serviceMock.Setup(s => s.DeletarEquipamento(equipamentoId));

            // Act
            var result = _controller.Delete(equipamentoId);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _serviceMock.Verify(s => s.DeletarEquipamento(equipamentoId), Times.Once);
        }
    }
}