# Get Started

## Download NOLO SDK For Unity
* download [NOLO SDK For Unity](https://github.com/LyrobotixNolo/Unity/tree/master/UnityPackage)to your loacl.
## Import to Unity
* Download and Install [Unity](https://unity3d.com).NOLO SDK For Unity develop with Unity5.4.1,It is recommended to use the Unity version or above this version.   

* Open Unity,Click “NEW”,Fill in your project name and path.Click “Creata project”,Create a new Unity project.  
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/createunityproject.png"></div>  

  * Click menu Assets->Import Package->Custom Package  
  
  <div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/importpackage.PNG"></div>  
  
* Browse to the path for NOLO SDK For Unity and open it.   

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/selectpackage.PNG"> </div> 
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/selectopen.png"></div>  

* Import complete.  

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/importfinish.png"></div>  

## Build Gear VR Example
* Open NoloVR\Example\General\Test 

* Click File->Build Setting,Click Add Open Scenes,Choose Android and Click Switch Playform.  
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/switch playform.png"></div>
* Click Player Settings,Modify Bundle Identifier,Check Virtual Reality Supported and Add Oculus SDK.  
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/playersetting.png"></div>  
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/settings.png"></div>  
* Click build,then install to mobile phone.
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/build.png"></div> 

## Build CardBoard Example
* Import [CardBoard SDK For Unity](https://developers.google.com/cardboard/unity/download)to the same way.

* Open NoloVR\Example\General\Test.  

* Put CardBoard GvrViewerMain in this Scene. 

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/vrcamera.png"></div>  

* Click File->Build Setting,Click Add Open Scenes,Choose Android,Click Switch Playform.  

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/switch playform.png"></div>  

* Click Player Settings,Modify Bundle Identifier。  

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/playersetting.png"></div>  
<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/cardboardsetting.png"></div>  

* Click build,then install to mobile phone.   

<div><img width = 400 heigh = 280 src="https://github.com/LyrobotixNolo/Unity/blob/master/Documents/Image/build.png"></div> 


## Other VR SDK
* Drag the helmet preform in SDK to NoloManager->Hmd(camera),Become Hmd(camera)'s child，Reset position and rotation.
* Find NoloVR_Manager.cs from NoloManager,Drag the Camera object that rotation really changes in the game's runtime to VR Camera.
* Other steps reference Gear VR and CardBoard.
