<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm4" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
     <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
     <script>
         const container = document.getElementById('container');
         const loading = document.querySelector('.loading');

         getPost();
         getPost();
         getPost();

         window.addEventListener('scroll', () => {
             const { scrollTop, scrollHeight, clientHeight } = document.documentElement;

             console.log({ scrollTop, scrollHeight, clientHeight });

             if (clientHeight + scrollTop >= scrollHeight - 5) {
                 // show the loading animation
                 showLoading();
             }
         });

         function showLoading() {
             loading.classList.add('show');

             // load more data
             setTimeout(getPost, 1000)
         }

         async function getPost() {
             const postResponse = await fetch(`https://jsonplaceholder.typicode.com/posts/${getRandomNr()}`);
             const postData = await postResponse.json();

             const userResponse = await fetch('https://randomuser.me/api');
             const userData = await userResponse.json();

             const data = { post: postData, user: userData.results[0] };

             addDataToDOM(data);
         }

         function getRandomNr() {
             return Math.floor(Math.random() * 100) + 1;
         }

         function addDataToDOM(data) {
             const postElement = document.createElement('div');
             postElement.classList.add('blog-post');
             postElement.innerHTML = `
		<h2 class="title">${data.post.title}</h2>
		<p class="text">${data.post.body}</p>
		<div class="user-info">
			<img src="${data.user.picture.large}" alt="${data.user.name.first}" />
			<span>${data.user.name.first} ${data.user.name.last}</span>
		</div>
	`;
             container.appendChild(postElement);

             loading.classList.remove('show');
         }
     </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
        <div class="container" id="container">
        <h1>Blog Posts</h1>
        <!-- 	<div class="blog-post">
                <h2 class="title">Blog post title</h2>
                <p class="text">Lorem ipsum dolor, sit amet consectetur adipisicing elit. Provident quod debitis in repellat veritatis minus ab ex maiores itaque quis.</p>
                <div class="user-info">
                    <img src="https://randomuser.me/api/portraits/women/26.jpg" alt="pic" />
                    <span>Leah Taylor</span>
                </div>
            </div> -->
    </div>

    <div class="loading">
        <div class="ball"></div>
        <div class="ball"></div>
        <div class="ball"></div>
    </div>

</body>
</html>
