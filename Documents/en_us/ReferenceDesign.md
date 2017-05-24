# Recenter

Reference design, the realization of the function is to double-click any system button of controllers to reset the camera Yaw value.
Add NoloVR_Recenter.cs script into NoloManager to reset camera YAW. The official recommendation is to double-click system button (power button) of any controller to reset the camera Yaw value. As Gear an example, in the actual development, the developer should to use a different method to replace the method in 30th line of NoloVR_Recenter.cs, according to the difference of VRCamera.

* Oculus
```
 UnityEngine.VR.InputTracking.Recenter();
```
* Google
```
GvrViewer.Instance.Recenter();
```

# RotateSceneDemo

Reference design, the realization of the function is pressing the Grip buttons of two controllers. Then you can rotate, zoom, and move the scene.
Add NoloVR_Recenter.cs script into NoloManager. Place all the objects which need to be changed in the scene under a parent node, and add the parent node into Object Parents under the NoloVR_RotateScene.cs script. Is change scale means whether you need to modify scale. Is change rotation means whether you need to modify rotation.

# Teleport

Reference design for implementing NOLO transfer function.
Add NoloVR_Teleport.cs script into any controller (leftcontroller or rightcontroller). That will do. 

# TurnAroundDemo

Reference design, the realization of the function is to Double-click the menu button of any controller to implement turn around the game scene 180 degrees.
Add NoloVR_Recenter.cs script into NoloManager. That will do.
