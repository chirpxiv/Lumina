using System;

namespace Lumina.Data.Parsing.Tex.Buffers
{
    /// <summary>
    /// Represent a face in .tex file, in L8 texture format.
    /// </summary>
    public class L8TextureBuffer : TextureBuffer
    {
        /// <inheritdoc />
        public L8TextureBuffer( bool isDepthConstant, int width, int height, int depth, int[] mipmapAllocations, byte[] buffer )
            : base( isDepthConstant, width, height, depth, mipmapAllocations, buffer )
        {
        }

        /// <inheritdoc />
        public override int NumBytesOfMipmapPerPlane( int mipmapIndex ) => NumPixelsOfMipmapPerPlane( mipmapIndex );

        /// <inheritdoc />
        protected override unsafe void ConvertToB8G8R8A8( byte[] buffer, int destOffset, int sourceOffset, int width, int height, int depth )
        {
            fixed( byte* dstb = buffer, srcb = RawData )
            {
                var src = new Span< byte >( srcb + sourceOffset, width * height * depth );
                var dst = new Span< uint >( dstb + destOffset, width * height * depth );
                for( var i = 0; i < dst.Length; i++ )
                    dst[ i ] = 0xFF000000U | ( 0x10101U * src[ i ] );
            }
        }

        /// <inheritdoc />
        protected override TextureBuffer CreateNew( bool isDepthConstant, int width, int height, int depth, int[] mipmapAllocations, byte[] buffer )
            => new L8TextureBuffer( isDepthConstant, width, height, depth, mipmapAllocations, buffer );
    }
}