using System;
using System.Collections;

namespace Assignment1_Age_Calculator
{

    class CalculateBirthDays
    {
        private TimeSpan age;
        private int itemNo;
        private int totalDays;
        private int ageInYears;
        private int ageInMonths;
        private int ageInDays;
        private int remainingDays;
        private int calculateLeapDays;
        private int noOfSiblings;
        private int differenceDays;
        private int differenceMonths;
        private int differenceYears;
        private int differenceRemainder;
        private int[] sortedArray;
        private ArrayList BDs;
        private int[] allTotalDays;
        private DateTime bd1;
        private DateTime currentDate;

        public CalculateBirthDays()
        {
            itemNo = 0;
            totalDays = 0;
            ageInYears = 0;
            ageInMonths = 0;
            ageInDays = 0;
            remainingDays = 0;
            calculateLeapDays = 0;
            noOfSiblings = 0;
            BDs = new ArrayList();
            bd1 = new DateTime();
            currentDate = DateTime.Now;
        }
        public int getSiblings()
        {

            this.noOfSiblings = int.Parse(Console.ReadLine());
            allTotalDays = new int[noOfSiblings]; // creating array for storing days of every sibling
            sortedArray = new int[noOfSiblings];
            return noOfSiblings;
        }
        public ArrayList setSiblingsDOB()
        {
            for (int i = 1; i <= this.noOfSiblings; i++)
            {
                Console.WriteLine("Please enter date of birth of sibling {0}", i);
                bd1 = DateTime.Parse(Console.ReadLine());
                if (bd1 > currentDate)
                {
                    Console.WriteLine("Invalid birthdate ");
                    break;
                }
                BDs.Add(bd1); //storing
            }
            return BDs;
        }

        public void CaclulateTotalDays(ArrayList BirthDayList)
        {
            BDs = BirthDayList;
            foreach (DateTime item in BDs)
            {
                age = currentDate.Subtract(item);
                totalDays = Convert.ToInt32(age.TotalDays);
                allTotalDays[itemNo] = totalDays;
                ageInYears = totalDays / 365;
                calculateLeapDays = ageInYears / 4;
                remainingDays = (totalDays % 365) - calculateLeapDays;
                ageInMonths = remainingDays / 30;
                ageInDays = remainingDays % 30;
                itemNo++;
                Console.WriteLine("Age of sibling {0} is {1} years {2} months {3} days", itemNo, ageInYears, ageInMonths, ageInDays);
            }
        }
        public int[] sortInDecending(int[] array)
        {
            int temp;
            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }

            return array;
        }
        public void CalculateDifference()
        {
            for (int i = 0; i < noOfSiblings; i++)
            {
                if (i != (allTotalDays.Length - 1))
                {
                    differenceDays = allTotalDays[i] - allTotalDays[i + 1];
                    if (differenceDays < 0)
                    {
                        differenceDays = differenceDays * (-1);
                    }
                    sortedArray[i] = differenceDays;

                }
            }
            sortedArray = sortInDecending(sortedArray);

            for (int i = 0; i < noOfSiblings - 1; i++)
            {
                differenceDays = sortedArray[i];
                differenceYears = differenceDays / 365;
                calculateLeapDays = differenceYears / 4;
                differenceRemainder = (differenceDays % 365) - calculateLeapDays;
                differenceMonths = differenceRemainder / 30;
                differenceDays = differenceRemainder % 30;
                Console.WriteLine("Difference of sibling {0} and  {1} is {2} years {3} months {4} days", i + 1, i + 2, differenceYears, differenceMonths, differenceDays);
            }
        }
    }
    class VpAssignment
    {
        static void Main()
        {
            CalculateBirthDays obj = new CalculateBirthDays();

            Console.WriteLine("Please enter Number of Siblings:");
            obj.getSiblings();
            ArrayList allDateOfBirths = obj.setSiblingsDOB();
            obj.CaclulateTotalDays(allDateOfBirths);
            Console.WriteLine("______________________________________________");

            Console.WriteLine("Showing Difference of ages from elder to younger \n");
            obj.CalculateDifference();

            Console.ReadLine();
        }
    }
}
