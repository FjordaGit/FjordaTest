# FjordaTest
 
 Unity Version Used: 2020.0.1f1
 
 The application has 3 pages and the user can click on the menu button at the bottom of the page to go through the pages. 
 
# Page 1
I show a list in Unity in the app from Json Placeholder https://jsonplaceholder.typicode.com/ with data from API: https://jsonplaceholder.typicode.com/photos
 
# Page 2
User clicks on the 3D cube and an animation of the cube plays. Once the user clicks the cube, we also change the UI text (which also has an animation).

# Page 3 
I show the list with text from https://jsonplaceholder.typicode.com/photos in a zoomable format while user swipes horizontaly. Snap functionality was also added into the horizontal list. 

Note:
1- I show only 20 items from the https://jsonplaceholder.typicode.com/photos but if we want to show more items or to show all items from API, we can change line 68 in VerticalScrollView.cs and line 115 in swipe.cs:

Change:

if (i >= 20) break;

to either comment out or delete or change the number 20 to how many items we want to show. 

2- The code in Unity to retreive the image from https://jsonplaceholder.typicode.com/photos is correct but it the server itself shows a 403 error. A problem with nameserver or server of https://jsonplaceholder.typicode.com/photos. 

# Requirements:
None, just download Unity Version 2020.0.1f1
