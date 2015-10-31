<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OriginalDefault.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Correlate</h1>
        <p class="lead">Unlocking the value within open data.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Get Started! &raquo;</a></p>
    </div>

    <div class="container-fluid">
        <p>
            This application uses Government datasets, freely available the data.gov.uk website. Datasets on their own can be difficult to interpret and draw meaningful information from. 
            We provide a tool to visualise one or more datasets in a single graph, from which comparisons and interpretations can be made more easily.
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
              Choose a dataset to display....
            </p>
             <img src="Images\tick.png" alt ="Green tick symbol" width="50" >
            <p>
               <!-- <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>-->
            </p>
        </div>
        <div class="col-md-4">
            <h2>View your graph</h2>
            
            <img src="Images\Graph.png" alt="Line graph" width="250" >
            <p>
                <!--<a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>-->
            </p>
        </div>
        <div class="col-md-4">
            <h2>Upload your own dataset</h2>
            <img src="Images\upload.png" alt="arrow pointing upward" width="100" />

            <p>
               <!-- <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>-->
            </p>
        </div>
    </div>

</asp:Content>
