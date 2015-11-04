<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OriginalDefault.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron"> 
            <h1 style="color:darkslategrey">Correlate</h1>
            <p style="color:darkslategrey" class="lead">Unlocking the value within open data.</p>      
            <p><a href="About.aspx" class="btn btn-primary btn-lg">Get Started! &raquo;</a></p>
    </div>

    <div class="container-fluid">
        <hr />
        <div class="row">
            <div class="col-md-8">
                 <p>This application uses Government datasets, freely available the data.gov.uk website</p>
                 <p> Datasets on their own can be difficult to interpret and draw meaningful information from.</p>
                 <p>We provide a tool to visualise one or more datasets in a single graph, from which comparisons and interpretations can be made more easily.</p>
            </div>
            <div class="col-md-4">
                <img src="Images\opendata.jpg" alt="Open data keywords image" width="350" />
            </div>
        </div>
        <hr />
    </div>

    <div class="well">
    <div class="row">
        <div class="col-md-4">
            <h3 class="text-center">Choose dataset to display</h3><hr />
             <img src="Images\tick.png" alt ="Green tick symbol" width="100" class="center-block" >
        </div>
        <div class="col-md-4">
            <h3 class="text-center">View your graph</h3><hr />  
            <img src="Images\Graph.png" alt="Line graph" width="250" class="center-block" >
        </div>
        <div class="col-md-4">
            <h3 class="text-center">Upload your own dataset</h3><hr />
            <img src="Images\upload.png" alt="arrow pointing upward" width="100" class="center-block"/>
        </div>
    </div>
   </div>

</asp:Content>
