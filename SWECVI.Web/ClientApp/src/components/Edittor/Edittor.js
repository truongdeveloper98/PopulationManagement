import { useCallback, useMemo, useRef } from 'react';
import { useMaterialUIController } from 'context';
import QuillEditor from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import styles from './styles.module.css';

function Edittor({ value = '', onChange = () => {}, readOnly = false }) {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;

  const quill = useRef();

  const imageHandler = useCallback(() => {
    const input = document.createElement('input');
    input.setAttribute('type', 'file');
    input.setAttribute('accept', 'image/*');
    input.click();

    input.onchange = () => {
      const file = input.files[0];
      if (!file) return;

      if (!file.type.startsWith('image/')) {
        alert('Please select a valid image file.');
        return;
      }

      const reader = new FileReader();
      reader.onload = () => {
        const imageUrl = reader.result;
        const quillEditor = quill.current?.getEditor();
        if (!quillEditor) return;

        const range = quillEditor.getSelection(true);
        quillEditor.insertEmbed(range.index, 'image', imageUrl, 'user');
      };

      reader.readAsDataURL(file);
    };
  }, []);

  const modules = useMemo(() => ({
    toolbar: {
      container: [
        [{ header: [2, 3, 4, false] }],
        ['bold', 'italic', 'underline', 'blockquote'],
        [{ color: [] }],
        [{ list: 'ordered' }, { list: 'bullet' }, { indent: '-1' }, { indent: '+1' }],
        ['link', 'image'],
        ['clean'],
      ],
      handlers: { image: imageHandler },
    },
    clipboard: { matchVisual: true },
  }), [imageHandler]);

  const formats = useMemo(() => [
    'header',
    'bold',
    'italic',
    'underline',
    'strike',
    'blockquote',
    'list',
    'bullet',
    'indent',
    'link',
    'image',
    'color',
    'clean',
  ], []);

  return (
    <div className={styles.wrapper}>
      <QuillEditor
        aria-label="Rich text editor"
        ref={(el) => {
          quill.current = el;
        }}
        className={darkMode ? styles.editordarkmode : styles.editor}
        theme="snow"
        preserveWhitespace="true"
        value={value}
        formats={formats}
        modules={modules}
        onChange={onChange}
        readOnly={readOnly}
      />
    </div>
  );
}

export default Edittor;
