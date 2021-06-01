using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace NameStorageWithLinkedLIsts
{
    public class Node
    {
        public String value;
        public Node next;
        public Node previous;
    }
    public class LinkedList
    {

        private Node head;

        public LinkedList()
        {
            head = new Node();
        }

        public void add(String toBeStored)
        {
            bool notDone = true;
            if (head.value == null)
            {
                Node toAdd = new Node();
                toAdd.value = toBeStored;
                head = toAdd;
            }
            else
            {
                Node search = head;
                Node searchBehind = head;
                String currentData;
                bool searchBehindNeedsMoved = false;

                while (notDone)
                {

                    currentData = search.value;
                    if (currentData[0] > toBeStored[0])
                    {
                        if (search == head)
                        {
                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            toAdd.next = head;
                            head.previous = toAdd;
                            head = toAdd;
                            notDone = false;
                        }
                        else
                        {

                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            toAdd.next = search;
                            toAdd.previous = searchBehind;
                            searchBehind.next = toAdd;
                            search.previous = toAdd;
                            notDone = false;

                        }
                    }
                    else if (currentData[0] == toBeStored[0])
                    {
                        bool stillTheSame = true;
                        int i = 1;
                        while (stillTheSame == true)
                        {
                            if (currentData[i] == toBeStored[i])
                                i++;
                            else
                                stillTheSame = false;
                        }

                        if (currentData[i] > toBeStored[i])
                        {

                            if (search != head)
                            {
                                Node toAdd = new Node();
                                toAdd.value = toBeStored;
                                toAdd.next = search;
                                toAdd.previous = searchBehind;
                                searchBehind.next = toAdd;
                            }
                            else
                            {
                                Node toAdd = new Node();
                                toAdd.value = toBeStored;
                                toAdd.next = head;
                                head.previous = toAdd;
                                head = toAdd;
                                notDone = false;
                            }
                        }

                    }
                    else
                    {
                        if (search.next == null)
                        {
                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            search.next = toAdd;
                            toAdd.previous = search;
                            notDone = false;
                        }
                        else
                        {
                            search = search.next;
                            if (searchBehindNeedsMoved)
                                searchBehind = searchBehind.next;
                            else
                                searchBehindNeedsMoved = true;
                        }
                    }

                }

            }

            return;

        }

        public String writeInOrder()
        {

            Node runThrough = new Node();
            runThrough = head;
            String building = "";

            while (runThrough.next != null)
            {
                building = building + " " + runThrough.value;
                runThrough = runThrough.next;
            }
            building = building + " " + runThrough.value;


            return building;

        }

        public String writeInReverseOrder()
        {

            Node runThrough = new Node();
            runThrough = head;
            String building = "";

            while(runThrough.next != null)
            {
                runThrough = runThrough.next;
            }

            while(runThrough.previous != null)
            {
                building += " " + runThrough.value;
                runThrough = runThrough.previous;
            }

            building += " " + runThrough.value;

            return building;

        }

    }
}
