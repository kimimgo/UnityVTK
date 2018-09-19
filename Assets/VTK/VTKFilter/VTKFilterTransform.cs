using UnityEngine;
using Kitware.VTK;

/*
 * Translate, rotate or scale
 * */

[ExecuteInEditMode]
public class VTKFilterTransform : VTKFilter 
{
	[HideInInspector]
	public float translateX = 0.0f;
	[HideInInspector]
	public float translateY = 0.0f;
	[HideInInspector]
	public float translateZ = 0.0f;

	[HideInInspector]
	public float rotateX = 0.0f;
	[HideInInspector]
	public float rotateY = 0.0f;
	[HideInInspector]
	public float rotateZ = 0.0f;

	[HideInInspector]
	public float scaleX = 1.0f;
	[HideInInspector]
	public float scaleY = 1.0f;
	[HideInInspector]
	public float scaleZ = 1.0f;

	[HideInInspector]
	public vtkTransform vtkTransform; 

	public override void Reset()
	{
		translateX = 0.0f;
		translateY = 0.0f;
		translateZ = 0.0f;

		rotateX = 0.0f;
		rotateY = 0.0f;
		rotateZ = 0.0f;

		scaleX = 1.0f;
		scaleY = 1.0f;
		scaleZ = 1.0f;
	}

	public override void SetPlaymodeParameters(){}

	protected override void ValidateInput(){}

	protected override void CalculateFilter()
	{
		outputType = VTK.DataType.PolyData;
		
		vtkFilter = Kitware.VTK.vtkTransformFilter.New ();

		vtkTransform = Kitware.VTK.vtkTransform.New ();

		vtkFilter.SetInputConnection (node.parent.filter.vtkFilter.GetOutputPort());

		SetTranslation ();
		SetRotation ();
		SetScale ();

		((vtkTransformFilter)vtkFilter).SetTransform (vtkTransform);

		vtkFilter.Update ();

		outputType = VTK.DataType.PolyData;
	}

	public void SetTranslation ()
	{
		vtkTransform.Translate (translateX, translateY, translateZ);
	}

	public void SetRotation()
	{
		vtkTransform.RotateX (rotateX);
		vtkTransform.RotateY (rotateY);
		vtkTransform.RotateZ (rotateZ);
	}

	public void SetScale()
	{
		vtkTransform.Scale (scaleX, scaleY, scaleZ);
	}
}
