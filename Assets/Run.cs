using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Run : MonoBehaviour
{
    public static bool end;
    
    public void Start()
    {
        StartCoroutine(_run());
    }

    private IEnumerator _run()
    {
        while (true)
        {
            yield return null;

            if (!end)
            {
                while (Data.Statements.Count > Data.CurrentProgramPos)
                {
                    Data.Statements[Data.CurrentProgramPos].Run();
                    Data.CurrentProgramPos++;

                    yield return null;
                }

                end = true;
                Data.MemoryReset();
            }
        }
    }
}
