using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kitware.VTK;

public class vtptest : MonoBehaviour {

    VtkToUnity vtkToUnity;
    //vtkXMLPolyDataReader reader;
    //vtkXMLUnstructuredDataReader readeru;
    vtkDataSetMapper mapper;
    vtkActor actor;
    vtkRenderer renderer;

    public GameObject currntVtk;

    string nameOfPrj;
    string nameOfPart;

    // Use this for initialization
    void Start () {
        LoadBoxVtp();
        RenderVtk();

    }
	
	// Update is called once per frame
	void Update () {

        if (currntVtk == null)
        {
            currntVtk = GameObject.Find("myPoly");
            //currntVtk.transform.Translate(10, 10, 10);
            
        }
        else if (currntVtk.transform.eulerAngles.x==0)
        {
            //currntVtk.transform.eulerAngles = new Vector3(currntVtk.transform.eulerAngles.x + 180f, currntVtk.transform.eulerAngles.y, 0);
        }
        else
        {
            currntVtk.transform.Rotate(new Vector3(0, 1), 1);
        }

    }

    void LoadBoxVtp()
    {
        vtkXMLPolyDataReader reader = vtkXMLPolyDataReader.New();
        //vtkXYZMolReader reader = vtkXYZMolReader.New();
        //vtkXMLUnstructuredGridReader reader = vtkXMLUnstructuredGridReader.New();
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\Points.vtp";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\hasselvorsperre.vtp";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\Box.vtp";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\river_lines.vtp";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\sand_with_vectors.vtu";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\model162_GROUNDWATER_FLOW10.vtk";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\";
        string filePath = @"C:\dev-repos\UnityVTK\UnityVTK\Assets\StreamingAssets\Vtk-Data\Test23.WaveSurface.t82.vtp";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\Slopefail_anim_68.vtu";
        //string filePath = @"C:\dev-repos\TIL\Unity\UnityVTK\Assets\StreamingAssets\Vtk-Data\PartBound_0000.vtk";
        reader.SetFileName(filePath);
        reader.Update();

        //readeru.SetFileName(filePath);
        //readeru.Update();

        mapper = vtkDataSetMapper.New();
        mapper.SetInputConnection(reader.GetOutputPort());

        actor = vtkActor.New();
        actor.SetMapper(mapper);
        vtkToUnity = new VtkToUnity(reader.GetOutputPort(), currntVtk);


    }

    void RenderVtk()
    {
        
        //vtkToUnity = new VtkToUnity(readeru.GetOutputPort(), "myPoly");
        //vtkToUnity = new VtkToUnity(reader.GetOutputPort(), "myPoly");
        //vtkToUnity = new VtkToUnity(mapper.GetOutputPort(), "myPoly");
        vtkToUnity.ColorBy(Color.grey);
        vtkToUnity.Update();
    }
}
