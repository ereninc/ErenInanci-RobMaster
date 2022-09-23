using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PoolModel : ObjectModel
{
    [SerializeField] List<ObjectModel> items;

    public virtual T GetDeactiveItem<T>()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].isActiveAndEnabled == false)
            {
                return (T)((object)items[i]);
            }
        }

        return default(T);
    }

    private void getItemsFromChilds()
    {
        if (items == null)
            items = new List<ObjectModel>();

        for (int i = 0; i < transform.childCount; i++)
        {
            ObjectModel item = transform.GetChild(i).GetComponent<ObjectModel>();
            if (item != null)
            {
                item.SetDeactive();
                items.Add(item);
            }
        }
    }
}
