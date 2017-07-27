﻿namespace OpenZH.Graphics
{
    public struct PipelineStateDescription
    {
        public PipelineLayout PipelineLayout;

        public VertexDescriptor VertexDescriptor;
        public Shader VertexShader;

        public Shader PixelShader;

        public PixelFormat RenderTargetFormat;
    }
}
