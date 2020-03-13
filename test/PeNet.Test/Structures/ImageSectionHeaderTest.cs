﻿using PeNet.FileParser;
using PeNet.Header.Pe;
using Xunit;

namespace PeNet.Test.Structures
{
    
    public class ImageSectionHeaderTest
    {
        [Fact]
        public void ImageSectionHeaderConstructorWorks_Test()
        {
            var sectionHeader = new ImageSectionHeader(new BufferFile(RawStructures.RawSectionHeader), 2, 0);

            Assert.Equal(".data", sectionHeader.Name);
            Assert.Equal((uint) 0x33221100, sectionHeader.VirtualSize);
            Assert.Equal((uint) 0x77665544, sectionHeader.VirtualAddress);
            Assert.Equal(0xbbaa9988, sectionHeader.SizeOfRawData);
            Assert.Equal(0xffeeddcc, sectionHeader.PointerToRawData);
            Assert.Equal((uint) 0x44332211, sectionHeader.PointerToRelocations);
            Assert.Equal(0x88776655, sectionHeader.PointerToLinenumbers);
            Assert.Equal((ushort) 0xaa99, sectionHeader.NumberOfRelocations);
            Assert.Equal((ushort) 0xccbb, sectionHeader.NumberOfLinenumbers);
            Assert.Equal((ScnCharacteristicsType) 0x00000820, sectionHeader.Characteristics);
            Assert.Equal(2, sectionHeader.CharacteristicsResolved.Count);
            Assert.Contains("LnkRemove", sectionHeader.CharacteristicsResolved);
            Assert.Contains("CntCode", sectionHeader.CharacteristicsResolved);
        }
    }
}