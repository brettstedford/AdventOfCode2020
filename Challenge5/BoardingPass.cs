﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge5
{
    public class BoardingPass
    {
        public int Row { get; }
        public int Column { get; }
        public int SeatNumber { get; }

        private const int NumberOfRows = 128;
        private const int NumberOfColumns = 8;

        private static readonly Dictionary<PartitionType, char> PartitionTypeCodes = new Dictionary<PartitionType, char>
        {
            {PartitionType.Row, 'F'},
            {PartitionType.Column, 'L'}
        };

        public BoardingPass(string binarySpacePartitionCode)
        {
            var rowCode = binarySpacePartitionCode.Substring(0, 7);
            var colCode = binarySpacePartitionCode.Substring(7, 3);
            Row = FindNextPartition(rowCode, PartitionType.Row, 0, NumberOfRows - 1).lowerBound;
            Column = FindNextPartition(colCode, PartitionType.Column, 0, NumberOfColumns - 1).lowerBound;
            SeatNumber = Row * 8 + Column;
        }
        
        private static readonly Func<int, int, int> CalculateBound = (l, u) => (u - l) / 2 + 1;
        
        private static (int lowerBound, int upperBound) FindNextPartition(string binarySpacePartitionCode, PartitionType partitionType, int lowerBound, int upperBound)
        {
            if (string.IsNullOrEmpty(binarySpacePartitionCode) || lowerBound == upperBound)
                return (lowerBound, upperBound);

            var nextCode = binarySpacePartitionCode.Substring(0, 1).ToCharArray().Single();
            var nextLowerBound = lowerBound;
            var nextUpperBound = upperBound;

            if (nextCode == PartitionTypeCodes[partitionType])
                nextUpperBound -= CalculateBound(lowerBound, upperBound);
            else
                nextLowerBound += CalculateBound(lowerBound, upperBound);

            return FindNextPartition(binarySpacePartitionCode.Substring(1, binarySpacePartitionCode.Length - 1), partitionType, nextLowerBound, nextUpperBound);
        }
    }
}