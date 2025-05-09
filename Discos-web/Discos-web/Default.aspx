<%@ Page Title="DiscosApp" Language="C#" MasterPageFile="~/Discos.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Discos_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container bg-light text-dark p-5 rounded shadow">
    <style>
        .hero {
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            justify-content: space-between;
        }

        .hero-text {
            flex: 1 1 50%;
            padding: 20px;
        }

        .hero-text h1 {
            font-size: 2.5rem;
            font-weight: bold;
        }

        .hero-text p {
            font-size: 1.1rem;
            margin-top: 1rem;
        }

        .btn-start {
            margin-top: 20px;
        }

        .carousel-container {
            flex: 1 1 40%;
            padding: 20px;
        }

        .carousel-inner img {
            border-radius: 15px;
            max-height: 300px;
            object-fit: cover;
        }
    </style>

    <div class="hero mt-5">
        <div class="hero-text">
            <h1>Bienvenido a tu app de discos favorita</h1>
            <p>Explorá los mejores álbumes, descubrí nuevos artistas y armá tu colección musical como nunca antes. Todo en una sola app, sencilla y poderosa.</p>
            <a href="/DiscosList.aspx" class="btn btn-primary btn-lg btn-start">Explorar discos</a>
        </div>
        <div class="carousel-container">
            <div id="carouselDiscos" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="https://f4.bcbits.com/img/a2136146268_16.jpg" class="d-block w-100" alt="Disco 1">
                    </div>
                    <div class="carousel-item ">
                        <img src="https://f4.bcbits.com/img/a2136146268_16.jpg" class="d-block w-100" alt="Disco 2">
                    </div>
                    <div class="carousel-item">
                        <img src="https://f4.bcbits.com/img/a2136146268_16.jpg" class="d-block w-100" alt="Disco 3">
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselDiscos" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon"></span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselDiscos" data-bs-slide="next">
                    <span class="carousel-control-next-icon"></span>
                </button>
            </div>
        </div>
    </div>
</div>
   
</asp:Content>
