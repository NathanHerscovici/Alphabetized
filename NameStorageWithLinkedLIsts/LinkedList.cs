using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace NameStorageWithLinkedLIsts
{
    //Class definition for the Node class.
    public class Node
    {
        public String value;
        public Node next;
        public Node previous;
    }

    //Class definition for the linked list class.
    public class LinkedList
    {

        private Node head;
        private Node foot;

        //Constructor for the class.
        public LinkedList()
        {
            head = new Node();
        }

        //Method to add a name to the linked list.
        public void add(String toBeStored)
        {
            bool notDone = true;

            //Checks to see if the list has just been created and needs its first node.
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
                    int comparison = String.Compare(toBeStored, currentData);

                    //Checks to see if the incoming name is alphabetically before the current node.
                    if (comparison < 0)
                    {
                        //If the current node is the head a node is added before the head, then the head is set as the new node.
                        if (search == head)
                        {
                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            toAdd.next = head;
                            head.previous = toAdd;
                            head = toAdd;
                            notDone = false;
                        }
                        //The node is added before the current node.
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
                    //Checks to see if the incoming name is alphabetically the same as the current node.
                    else if (comparison == 0)
                    {
                        //If the current node is the head a node is added before the head, then the head is set as the new node.
                        if (search != head)
                        {
                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            toAdd.next = search;
                            toAdd.previous = searchBehind;
                            searchBehind.next = toAdd;
                        }
                        ////The node is added before the current node.
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
                    //The default situation, which is when the incoming name comes after the current node.
                    else
                    {
                        //If there is no next node in the list the node will be tacked onto the end and the foot is incremented.
                        if (search.next == null)
                        {
                            Node toAdd = new Node();
                            toAdd.value = toBeStored;
                            search.next = toAdd;
                            toAdd.previous = search;
                            foot = toAdd;
                            notDone = false;
                        }
                        //Otherwise the variables used to search through the list are moved forward.
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

        //The method to write the names to be sent in order.
        //A string to be returned is built by a variable running through the list in order and building a string of all the names.
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

        //The method to write the names to be sent in reverse order.
        //A string to be returned is built by a variable running through the list in reverse order and building a string of all the names.
        public String writeInReverseOrder()
        {

            Node runThrough = new Node();
            runThrough = foot;
            String building = "";

            while (runThrough.previous != null)
            {
                building += " " + runThrough.value;
                runThrough = runThrough.previous;
            }

            building += " " + runThrough.value;

            return building;

        }

    }
}
