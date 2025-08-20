using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class ImfResponse<T>
    {
        /// <summary>
        /// Any validation or business errors.
        /// </summary>
        public List<ImfErrors> Errors { get; set; } = new List<ImfErrors>();

        /// <summary>
        /// The actual response data (generic type).
        /// </summary>
        public T Data { get; set; } = default!; // Fix for CS8618: Ensure Data is initialized.

        /// <summary>
        /// Additional message (success or failure details).
        /// </summary>
        public string Message { get; set; } = string.Empty; // Fix for CS8618: Ensure Message is initialized.

        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public bool Success => Errors == null || Errors.Count == 0;

        // Fix for CS1520: Add return type to constructor.
        public ImfResponse() { }

        public ImfResponse(T data, string? message = null)
        {
            Data = data;
            Message = message ?? string.Empty; // Ensure Message is not null.
        }

        public ImfResponse(List<ImfErrors> errors, string? message = null)
        {
            Errors = errors ?? [];
            Message = message ?? string.Empty; // Ensure Message is not null.
        }
    }

}
