﻿using System.IO;
using OpenSage.Data.Utilities.Extensions;

namespace OpenSage.Data.W3d
{
    public sealed class W3dCollectionHeader : W3dChunk
    {
        public override W3dChunkType ChunkType { get; } = W3dChunkType.W3D_CHUNK_COLLECTION_HEADER;

        public uint Version { get; private set; }

        public string Name { get; private set; }

        public uint RenderObjectCount { get; private set; }

        internal static W3dCollectionHeader Parse(BinaryReader reader, W3dParseContext context)
        {
            return ParseChunk(reader, context, header =>
            {
                var result = new W3dCollectionHeader
                {
                    Version = reader.ReadUInt32()
                };

                var nameSize = (int)context.CurrentEndPosition - (int)reader.BaseStream.Position - 4;
                result.Name = reader.ReadFixedLengthString(nameSize);
                result.RenderObjectCount = reader.ReadUInt32();

                return result;
            });
        }

        protected override void WriteToOverride(BinaryWriter writer)
        {
            writer.Write(Version);
            writer.Write(Name);
            writer.Write(RenderObjectCount);
        }
    }
}
