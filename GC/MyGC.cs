abstract class MyGC{

    private int Generation0Size;
    private int Generation1Size;
    private int Generation2Size;
    private ICollection<Object> FinalizarionQueue;

    public void GC(){
        //First step in GC
         StopAllThreads();
        List<Object> roots = GetRoots();
        for(int i = 0; i < roots.size(); i++)
            Mark(roots.get(i));
        Sweep();
        FixGenerationSize();
    }

    void Mark(Object* pObj)
    {
    if (!Marked(pObj)) // Marked returns the marked flag from object header
    {
        MarkBit(pObj); // Marks the flag in obj header

        ObjectCollection children = pObj->GetChildren();
        for(int i = 0; i < children.Count(); ++i)
        {
            Mark(children[i]); // recursively call mark
        }	
    }
    }

    void Sweep()
    {
        Object *pHeap = pHeapStart;
        while(pHeap < pHeapEnd)
        {
            if (!Marked(pHeap))
                Free(pHeap); // put it to the free object list
            else{
                UnMarkBit(pHeap);
                GetCurrentGeneration().Add(pHeap);
                }

            pHeap = GetNext(pHeap);
        }
    }

    //Change generation size after every GC
    private abstract void FixGenerationSize();

    //add to FinalizationQueue
    private void Free(Object o){
        FinalizarionQueue.add(o);
    }

    //Change their pointers
    //if size of an object is big enougth, it is stored in another
    //memory place
    private abstract void MoveSurvivedObjects();

    //returns generation, in which the GC is working
    //has method Add() to add an object to it
    private abstract Generation GetCurrentGeneration();
}