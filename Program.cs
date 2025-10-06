// See https://aka.ms/new-console-template for more information
// 10/6/2025 Treasure Grabber for Team Compitition
// UW-Stout Algorithms 2025-26
// Luke Kedrowski
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Treasure_Grabber;

//merge implementation
void Merge(Treasure[] arr,int left,int right,int middle)
{
    Treasure[] low = new Treasure[middle - left + 1];
    Treasure[] high = new Treasure[right - middle];
    for(int a = 0;a < low.Length;a++)
    {
        low[a] = arr[a + left];
    }
    for(int a = 0; a < high.Length; a++)
    {
        high[a] = arr[a + middle + 1];
    }
    int i = 0;
    int j = 0;
    int k = left;
    while(i < low.Length && j < high.Length)
    {
        if (low[i].weightedValue >= high[j].weightedValue)
        {
            arr[k] = low[i];
            i++;
            k++;
        }
        else
        {
            arr[k] = high[j];
            k++;
            j++;
        }
    }
    while (i < low.Length)
    {
        arr[k] = low[i];
        k++;
        i++;
    }
    while(j < high.Length)
    {
        arr[k] = high[j];
        k++;
        j++;
    }
}
//mergesort implementation
 void mergeSort(Treasure[] arr,int left,int right) { 
    int mid = left +(right-left)/2;
    if (left < right) {
        mergeSort(arr,left,mid);
        mergeSort(arr, mid+1,right);
        Merge(arr,left, right,mid);
    }
}



Bag bag = new Bag(4000);
//get file location
Console.WriteLine("Insert Path to File: ");
string fileName = Console.ReadLine().Trim();
Stopwatch time = Stopwatch.StartNew();
//opens file

StreamReader reader = new StreamReader(fileName);
string line;
int count = 0;
//counts number of lines in file
while ((line = reader.ReadLine()) != null)
{
    count++;
}
reader.Close();
//creates a list that is the size of the file
Treasure[] cave = new Treasure[count];
count = 0;
//reopens file
reader = new StreamReader(fileName);
//adds each treasure to cave(list)
while ((line = reader.ReadLine()) != null)
{
    string name = line.Substring(0,line.IndexOf(','));
    line = line.Substring(line.IndexOf(',') + 1);
    int value = Convert.ToInt32(line.Substring(0,line.IndexOf(',')));
    line = line.Substring(line.IndexOf(',') + 1);
    int weight = Convert.ToInt32(line);
    cave[count] = (new Treasure(name, value, weight));
    count++;
}
//sort the cave by value per weight
mergeSort(cave, 0, cave.Length-1);
//initaiting tracking values
int currweight = 0;
int totalValue = 0;
foreach (Treasure t in cave)
{
    //assuemes cave is sorted puts each item that can fit into the bag into the bag and keeps track of value and weight
    if (currweight + t.weight < bag.maxWeight)
    {
        currweight += t.weight;
        bag.container.Add(t);
        totalValue += t.value;
    }
}

Console.WriteLine("Total Bag Value: " + totalValue);
Console.WriteLine("Total Bag Weight: " + currweight);

Console.WriteLine("Time Taken: " + time.ToString());
