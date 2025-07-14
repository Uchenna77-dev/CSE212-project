List<int> FindIntersection(List<int> list1, List<int> list2)
{
    var set1 = new HashSet<int>(list1);
    var result = new List<int>();

    foreach (var item in list2)
    {
        if (set1.Contains(item))
        {
            result.Add(item);
        }
    }

    return result;
}


List<int> FindUnion(List<int> list1, List<int> list2)
{
    var unionSet = new HashSet<int>();

    foreach (var item in list1)
    {
        unionSet.Add(item);
    }

    foreach (var item in list2)
    {
        unionSet.Add(item);
    }

    return unionSet.ToList();
}


A = [1, 2, 3], B = [2, 3, 4] → Result: [2, 3]

A = [], B = [1, 2] → Result: []

A = [5, 6], B = [7, 8] → Result: [] (no intersection)


A = [1, 2, 3], B = [2, 3, 4] → Result: [1, 2, 3, 4]

A = [], B = [1, 2] → Result: [1, 2]

A = [1, 1, 2], B = [2, 3] → Result: [1, 2, 3] (handles duplicates)